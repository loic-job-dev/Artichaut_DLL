using System.Linq;
using ArtichautDesktopApp.Models;

namespace ArtichautDesktopApp.ViewModels.Option;

public class BookingSummaryViewModel : ViewModelBase
{
    
    public BookingCardViewModel BookingCard { get; }
    public BookingSummaryViewModel(Booking booking)
    {
        string optionList = "Liste des options :\n";

        foreach (var option in booking.Options)
        {
            optionList += option.Name + "\n";
        }
        
        string bookingDescription = 
            $"Du {booking.StartDate:dd/MM/yyyy} au {booking.EndDate:dd/MM/yyyy}, " +
            $"pour {booking.AdultCount + booking.ChildrenCount} personnes, " +
            $"en {booking.RoomTypes.FirstOrDefault()?.Description ?? "chambre"}.\n" +
            $"Chambre {booking.Rooms.FirstOrDefault()?.Number}.\n\n" +
            optionList;
            
        BookingCard = new BookingCardViewModel(
            booking,
            bookingDescription);
    }
}