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
    // private readonly IBookingService _bookingService;
    private readonly IOptionService _optionService;

    public ObservableCollection<BookingCardViewModel> Bookings { get; }

    public BookingForOptionViewModel(
        List<Booking> bookings,
        // IBookingService bookingService,
        IOptionService optionService,
        string buttonName)
    {
        // _bookingService = bookingService;
        _optionService = optionService;

        Bookings = new ObservableCollection<BookingCardViewModel>();

        foreach (var booking in bookings)
        {
            string bookingDescription = 
            $"Du {booking.StartDate:dd/MM/yyyy} au {booking.EndDate:dd/MM/yyyy}, " +
                $"pour {booking.AdultCount + booking.ChildrenCount} personnes, " +
                $"en {booking.RoomTypes.FirstOrDefault()?.Description ?? "chambre"}.\n" +
                $"Chambre {booking.Rooms[0].Number}.";
            
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
        var result = await _optionService.GetOptions();
        
        if (result.Success)
        {
            Console.WriteLine(result.Data[0].Description);
            Console.WriteLine(result.Data[1].Description);
        }
        else
        {
            Console.WriteLine(result.ErrorMessage);
        }
    }
}