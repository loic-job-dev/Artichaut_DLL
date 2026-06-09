using System.Linq;
using ArtichautDesktopApp.Models;
using ArtichautLibrary;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ArtichautDesktopApp.ViewModels;

public partial class BookingCardViewModel : ViewModelBase
{
    public Booking Booking { get; }

    public BookingCardViewModel(Booking booking)
    {
        Booking = booking;
    }

    public string Description =>
        $"Du {Booking.StartDate:dd/MM/yyyy} au {Booking.EndDate:dd/MM/yyyy}, " +
        $"pour {Booking.AdultCount + Booking.ChildrenCount} personnes, " +
        $"en {Booking.RoomTypes.FirstOrDefault()?.Description ?? "chambre"}.";

    [RelayCommand]
    private void CheckIn()
    {
        // Appel API
    }
}