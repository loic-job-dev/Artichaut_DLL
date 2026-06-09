using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using ArtichautDesktopApp.Mappers;
using ArtichautDesktopApp.Models;
using ArtichautLibrary.Services;

namespace ArtichautDesktopApp.ViewModels;

public class BookingResultsViewModel : ViewModelBase
{
    private readonly IBookingService _bookingService;

    public ObservableCollection<BookingCardViewModel> Bookings { get; }

    public BookingResultsViewModel(
        List<Booking> bookings,
        IBookingService bookingService)
    {
        _bookingService = bookingService;

        Bookings = new ObservableCollection<BookingCardViewModel>();

        foreach (var booking in bookings)
        {
            var card = new BookingCardViewModel(booking);

            card.CheckInRequested += async bookingToCheckIn =>
                await OnCheckInRequested(bookingToCheckIn);

            Bookings.Add(card);
        }
    }
    
    private async Task OnCheckInRequested(Booking booking)
    {
        var result = await _bookingService.Checkin(
            booking.Status.ToString(), 
            booking.StartDate, 
            booking.RoomTypes[0].Id.ToString(), 
            booking.Id.ToString());
        
        if (result.Success)
        {
            var bookingResult = result.Data.ToModel();

            Console.WriteLine(bookingResult.ToString());
            
        }
        else
        {
            
            Console.WriteLine(result.ErrorMessage);
        }
    }
}