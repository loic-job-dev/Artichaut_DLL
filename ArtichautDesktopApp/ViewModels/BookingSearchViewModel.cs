using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ArtichautLibrary;
using ArtichautLibrary.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ArtichautDesktopApp.ViewModels;

public partial class BookingSearchViewModel : ViewModelBase
{
    private  readonly IBookingService _bookingService;
    
    [ObservableProperty]
    private string lastName = "";

    [ObservableProperty]
    private string firstName = "";

    [ObservableProperty]
    private string errorMessage = "";
    
    // Event to change the ViewModel in CheckinViewModel
    public event Action<List<BookingResponse>>? SearchSucceeded;

    
    public BookingSearchViewModel(IBookingService bookingService)
    {
        _bookingService = bookingService;
    }
    
    
    [RelayCommand]
    private async Task GetBookingsToCheckinByClient()
    {
        var result = await _bookingService.GetBookingsToCheckinByClient(
            firstName,
            lastName);
        
        if (result.Success)
        {
            Console.WriteLine(result.Data.ToString());
            SearchSucceeded?.Invoke(result.Data);
        }
        else
        {
            Console.WriteLine(result.ErrorMessage);
        }
    }
}