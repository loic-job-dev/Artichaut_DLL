using ArtichautDesktopApp.Services;
using ArtichautLibrary.Services;
using CommunityToolkit.Mvvm.ComponentModel;

namespace ArtichautDesktopApp.ViewModels;

public partial class OptionViewModel : ViewModelBase
{
    private readonly INavigationService _navigation;
    private  readonly IBookingService _bookingService;

    public SideMenuViewModel SideMenu { get; }
    
    [ObservableProperty]
    private ViewModelBase currentContent;
    
    public OptionViewModel(
        SideMenuViewModel sideMenu, 
        INavigationService navigation, 
        BookingCheckoutSearchViewModel searchVm, 
        IBookingService bookingService)
    {
        SideMenu = sideMenu;
        _navigation = navigation;
        _bookingService = bookingService;
        
        searchVm.SearchSucceeded += bookings =>
        {
            CurrentContent =
                new BookingCheckoutResultsViewModel(bookings, bookingService, "Ajouter");
        };
        
        CurrentContent = searchVm;
    }
}