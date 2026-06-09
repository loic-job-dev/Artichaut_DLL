using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ArtichautDesktopApp.Models;
using ArtichautLibrary;

namespace ArtichautDesktopApp.ViewModels;

public class BookingResultsViewModel : ViewModelBase
{
    public ObservableCollection<BookingCardViewModel> Bookings { get; }

    public BookingResultsViewModel(
        List<Booking> bookings)
    {
        Bookings = new ObservableCollection<BookingCardViewModel>(
            bookings.Select(x => new BookingCardViewModel(x))
        );
    }
}