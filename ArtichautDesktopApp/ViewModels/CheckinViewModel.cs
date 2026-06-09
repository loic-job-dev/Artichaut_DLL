using ArtichautDesktopApp.Services;
using ArtichautLibrary.Services;
using CommunityToolkit.Mvvm.ComponentModel;

namespace ArtichautDesktopApp.ViewModels;

public partial class CheckinViewModel : ViewModelBase
{
    private readonly INavigationService _navigation;
    private  readonly IBookingService _bookingService;

    public SideMenuViewModel SideMenu { get; }
    
    [ObservableProperty]
    private ViewModelBase currentContent;
    
    public CheckinViewModel(
        SideMenuViewModel sideMenu, 
        INavigationService navigation, 
        BookingSearchViewModel searchVm, 
        IBookingService bookingService)
    {
        SideMenu = sideMenu;
        _navigation = navigation;
        _bookingService = bookingService;
        
        searchVm.SearchSucceeded += bookings =>
        {
            CurrentContent =
                new BookingResultsViewModel(bookings);
        };
        
        CurrentContent = searchVm;
    }
}