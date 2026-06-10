using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ArtichautDesktopApp.Models;

namespace ArtichautDesktopApp.ViewModels.Option;

public class OptionAdditionViewModel : ViewModelBase
{
    public BookingCardViewModel BookingCard { get; }

    public OptionListViewModel OptionList { get; }

    public OptionAdditionViewModel(
        Booking booking,
        List<Models.Option> options)
    {
        string bookingDescription =
            $"Du {booking.StartDate:dd/MM/yyyy} au {booking.EndDate:dd/MM/yyyy}, " +
            $"pour {booking.AdultCount + booking.ChildrenCount} personnes, " +
            $"en {booking.RoomTypes.FirstOrDefault()?.Description ?? "chambre"}.\n" +
            $"Chambre {booking.Rooms.FirstOrDefault()?.Number}.";

        BookingCard = new BookingCardViewModel(
            booking,
            bookingDescription);

        OptionList = new OptionListViewModel(options);
    }
}