using System;
using System.Linq;
using System.Threading.Tasks;
using ArtichautDesktopApp.Mappers;
using ArtichautDesktopApp.Models;
using ArtichautLibrary;
using ArtichautLibrary.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ArtichautDesktopApp.ViewModels;

public partial class BookingCardViewModel : ViewModelBase
{
    private  readonly IBookingService _bookingService;
    public Booking Booking { get; }
    
    public event Action<Booking>? BookingSucceeded;

    public BookingCardViewModel(
        Booking booking,
        IBookingService bookingService)
    {
        Booking = booking;
        _bookingService = bookingService;
    }

    public string Description =>
        $"Du {Booking.StartDate:dd/MM/yyyy} au {Booking.EndDate:dd/MM/yyyy}, " +
        $"pour {Booking.AdultCount + Booking.ChildrenCount} personnes, " +
        $"en {Booking.RoomTypes.FirstOrDefault()?.Description ?? "chambre"}.";

    
    
    [RelayCommand]
    private async Task CheckIn()
    {
        
        Console.WriteLine($"Status      : {Booking.Status}");
        Console.WriteLine($"StartDate   : {Booking.StartDate}");
        Console.WriteLine($"RoomTypeId  : {Booking.RoomTypes[0].Id}");
        Console.WriteLine($"BookingId   : {Booking.Id}");
        
        var result = await _bookingService.Checkin(
            Booking.Status.ToString(), 
            Booking.StartDate, 
            Booking.RoomTypes[0].Id.ToString(), 
            Booking.Id.ToString());
        
        if (result.Success)
        {
            var booking = result.Data.ToModel();

            Console.WriteLine(booking.ToString());
            BookingSucceeded?.Invoke(booking);
        }
        else
        {
            // errorMessage = result.ErrorMessage;
            Console.WriteLine(result.ErrorMessage);
        }
    }
}