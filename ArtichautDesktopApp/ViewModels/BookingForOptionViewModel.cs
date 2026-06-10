using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using ArtichautDesktopApp.Mappers;
using ArtichautDesktopApp.Models;
using ArtichautLibrary.Services;
using CommunityToolkit.Mvvm.Input;

namespace ArtichautDesktopApp.ViewModels;

public class BookingForOptionViewModel : ViewModelBase
{
    private readonly IBookingService _bookingService;

    public ObservableCollection<BookingCardViewModel> Bookings { get; }

    public BookingForOptionViewModel(
        List<Booking> bookings,
        IBookingService bookingService,
        string buttonName)
    {
        _bookingService = bookingService;

        Bookings = new ObservableCollection<BookingCardViewModel>();

        foreach (var booking in bookings)
        {
            string bookingDescription = 
            $"Du {booking.StartDate:dd/MM/yyyy} au {booking.EndDate:dd/MM/yyyy}, " +
                $"pour {booking.AdultCount + booking.ChildrenCount} personnes, " +
                $"en {booking.RoomTypes.FirstOrDefault()?.Description ?? "chambre"}.";
            
            var card = new BookingCardViewModel(
                booking,
                bookingDescription,
                buttonName,
                new AsyncRelayCommand(() => OnAddOptionRequested(booking))
            );

            Bookings.Add(card);
        }
    }
    
    
    private async Task OnAddOptionRequested(Booking booking)
    {
        var result = await _bookingService.Checkout(
            booking.Id.ToString());
        
        if (result.Success)
        {
            var bookingResult = result.Data.ToModel();
            
            string bookingDescription = 
                $"Du {bookingResult.StartDate:dd/MM/yyyy} au {bookingResult.EndDate:dd/MM/yyyy}, " +
                $"pour {bookingResult.AdultCount + bookingResult.ChildrenCount} personnes, " +
                $"en {bookingResult.RoomTypes.FirstOrDefault()?.Description ?? "chambre"}.\n" +
                $"Chambre {bookingResult.Rooms[0].Number}";
            
            var card = new BookingCardViewModel(
                bookingResult,
                bookingDescription,
                null,
                null);
            
            Bookings.Clear();
            Bookings.Add(card);
            
        }
        else
        {
             Console.WriteLine(result.ErrorMessage);
        }
    }
}