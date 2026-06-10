using System.Linq;
using ArtichautDesktopApp.Models;

namespace ArtichautDesktopApp.ViewModels.Option;

public class BookingSummaryViewModel : ViewModelBase
{
    public BookingSummaryViewModel(Booking booking)
    {
        string bookingDescription = 
            $"Du {booking.StartDate:dd/MM/yyyy} au {booking.EndDate:dd/MM/yyyy}, " +
            $"pour {booking.AdultCount + booking.ChildrenCount} personnes, " +
            $"en {booking.RoomTypes.FirstOrDefault()?.Description ?? "chambre"}.\n" +
            $"Chambre {booking.Rooms.FirstOrDefault()?.Number}.";
            
        var card = new BookingCardViewModel(
            booking,
            bookingDescription,
            null,
            null);
        
        
    }
}