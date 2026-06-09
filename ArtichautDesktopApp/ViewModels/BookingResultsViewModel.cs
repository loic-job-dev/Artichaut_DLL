using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ArtichautDesktopApp.Models;
using ArtichautLibrary;
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

        Bookings = new ObservableCollection<BookingCardViewModel>(
            bookings.Select(x =>
                new BookingCardViewModel(x, _bookingService))
        );
    }
}