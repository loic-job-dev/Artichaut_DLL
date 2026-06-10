using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ArtichautDesktopApp.Models;
using ArtichautLibrary.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ArtichautDesktopApp.ViewModels;

public abstract partial class BookingSearchBaseViewModel : ViewModelBase
{
    protected readonly IBookingService BookingService;

    [ObservableProperty]
    private string lastName = "";

    [ObservableProperty]
    private string firstName = "";

    [ObservableProperty]
    private string errorMessage = "";

    public event Action<List<Booking>>? SearchSucceeded;

    protected BookingSearchBaseViewModel(
        IBookingService bookingService)
    {
        BookingService = bookingService;
    }

    protected void RaiseSearchSucceeded(List<Booking> bookings)
    {
        SearchSucceeded?.Invoke(bookings);
    }
    
    [RelayCommand]
    private async Task Search()
    {
        await ExecuteSearch();
    }

    protected abstract Task ExecuteSearch();
}