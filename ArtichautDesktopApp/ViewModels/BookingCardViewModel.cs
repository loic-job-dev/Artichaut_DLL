using System.Linq;
using ArtichautDesktopApp.Models;

using CommunityToolkit.Mvvm.Input;

namespace ArtichautDesktopApp.ViewModels;

public partial class BookingCardViewModel : ViewModelBase
{
    public Booking Booking { get; }
    
    public string? BookingDescription { get; }

    public string? ActionText { get; }

    public bool HasAction => ActionCommand != null;

    public IRelayCommand? ActionCommand { get; }

    public BookingCardViewModel(
        Booking booking,
        string? bookingDescription,
        string? actionText = null,
        IRelayCommand? actionCommand = null)
    {
        Booking = booking;
        BookingDescription = bookingDescription;
        ActionText = actionText;
        ActionCommand = actionCommand;
    }
}