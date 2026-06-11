using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using ArtichautDesktopApp.Mappers;
using ArtichautDesktopApp.Models;
using ArtichautLibrary.Services;
using CommunityToolkit.Mvvm.Input;

namespace ArtichautDesktopApp.ViewModels.Checkout;

public class BookingCheckoutResultsViewModel : ViewModelBase
{
    private readonly IBookingService _bookingService;

    public ObservableCollection<BookingCardViewModel> Bookings { get; }

    public BookingCheckoutResultsViewModel(
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
                $"en {booking.RoomTypes.FirstOrDefault()?.Description ?? "chambre"}.\n" +
                $"Chambre {booking.Rooms.FirstOrDefault()?.Number}.";
            
            var card = new BookingCardViewModel(
                booking,
                bookingDescription,
                buttonName,
                new AsyncRelayCommand(() => OnCheckOutRequested(booking))
            );

            Bookings.Add(card);
        }
    }
    
    
    private async Task OnCheckOutRequested(Booking booking)
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
                $"Chambre {bookingResult.Rooms[0].Number}.\n" +
                $"\nMontant TTC à régler : {bookingResult.TotalPrice} €";
            
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
             // Console.WriteLine(result.ErrorMessage);
        }
    }
}