using System.Linq;
using System.Threading.Tasks;
using ArtichautDesktopApp.Mappers;
using ArtichautLibrary.Services;
using CommunityToolkit.Mvvm.Input;

namespace ArtichautDesktopApp.ViewModels.Checkin;

public partial class BookingCheckinSearchViewModel
    : BookingSearchBaseViewModel
{
    public BookingCheckinSearchViewModel(
        IBookingService bookingService)
        : base(bookingService)
    {
    }

    [RelayCommand]
    protected override async Task ExecuteSearch()
    {
        var result =
            await BookingService.GetBookingsToCheckinByClient(
                FirstName,
                LastName);

        if (!result.Success)
        {
            ErrorMessage = result.ErrorMessage;
            return;
        }

        RaiseSearchSucceeded(
            result.Data.Select(x => x.ToModel()).ToList());
    }
}