using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ArtichautLibrary;

namespace ArtichautDesktopApp.ViewModels;

public class BookingResultsViewModel : ViewModelBase
{
    public ObservableCollection<BookingCardViewModel> Bookings { get; }

    public BookingResultsViewModel(
        List<BookingResponse> bookings)
    {
        Bookings = new ObservableCollection<BookingCardViewModel>(
            bookings.Select(x => new BookingCardViewModel(x))
        );
    }
}