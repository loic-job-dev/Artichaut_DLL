using System;
using System.Linq;
using System.Threading.Tasks;
using ArtichautDesktopApp.Models;
using CommunityToolkit.Mvvm.Input;

namespace ArtichautDesktopApp.ViewModels;

public partial class BookingCardViewModel : ViewModelBase
{
    public Booking Booking { get; }
    
    public event Func<Booking, Task>? CheckInRequested;

    public BookingCardViewModel(
        Booking booking)
    {
        Booking = booking;
    }

    public string Description =>
        $"Du {Booking.StartDate:dd/MM/yyyy} au {Booking.EndDate:dd/MM/yyyy}, " +
        $"pour {Booking.AdultCount + Booking.ChildrenCount} personnes, " +
        $"en {Booking.RoomTypes.FirstOrDefault()?.Description ?? "chambre"}.";

    
    
    [RelayCommand]
    private async Task CheckIn()
    {
        if (CheckInRequested != null)
            await CheckInRequested.Invoke(Booking);
    }
}