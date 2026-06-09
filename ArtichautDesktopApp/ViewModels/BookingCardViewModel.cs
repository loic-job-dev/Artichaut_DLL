using System.Linq;
using ArtichautLibrary;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ArtichautDesktopApp.ViewModels;

public partial class BookingCardViewModel : ViewModelBase
{
    public BookingResponse Booking { get; }

    public BookingCardViewModel(BookingResponse booking)
    {
        Booking = booking;
    }

    public string Description =>
        $"Du {Booking.StartBookedDate:dd/MM/yyyy} au {Booking.EndBookedDate:dd/MM/yyyy}, " +
        $"pour {Booking.AdultNumber + Booking.ChildrenNumber} personnes, " +
        $"en {Booking.RoomTypes.FirstOrDefault()?.Description ?? "chambre"}.";

    [RelayCommand]
    private void CheckIn()
    {
        // Appel API
    }
}