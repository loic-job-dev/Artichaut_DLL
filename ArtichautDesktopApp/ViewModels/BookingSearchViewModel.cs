using System;
using System.Threading.Tasks;
using ArtichautLibrary.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ArtichautDesktopApp.ViewModels;

public partial class BookingSearchViewModel : ViewModelBase
{
    private  readonly IBookingService _bookingService;
    
    public BookingSearchViewModel(IBookingService bookingService)
    {
        _bookingService = bookingService;
    }
    
    [ObservableProperty]
    private string lastName = "";

    [ObservableProperty]
    private string firstName = "";

    [ObservableProperty]
    private string errorMessage = "";

    [RelayCommand]
    private async Task SearchFoCheckin()
    {
        var result = await _bookingService.GetBookingsToCheckinByClient(FirstName, LastName);
        
        if (result.Success)
        {
            ErrorMessage = result.Data.ToString();
        }
        else
        {
            ErrorMessage = result.ErrorMessage;
        }
    }
}