using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArtichautLibrary.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ArtichautDesktopApp.Mappers;
using ArtichautDesktopApp.Models;

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
    public event Action<List<Booking>>? SearchSucceeded;

    
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
            var bookings = result.Data
                .Select(x => x.ToModel())
                .ToList();

            SearchSucceeded?.Invoke(bookings);
        }
        else
        {
            errorMessage = result.ErrorMessage;
        }
    }
}