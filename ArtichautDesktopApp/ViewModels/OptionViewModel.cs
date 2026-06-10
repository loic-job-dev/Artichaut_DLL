using ArtichautDesktopApp.Services;
using ArtichautLibrary.Services;
using CommunityToolkit.Mvvm.ComponentModel;

namespace ArtichautDesktopApp.ViewModels;

public partial class OptionViewModel : ViewModelBase
{
    private readonly INavigationService _navigation;
    private  readonly IBookingService _bookingService;
    private readonly IOptionService _optionService;

    public SideMenuViewModel SideMenu { get; }
    
    [ObservableProperty]
    private ViewModelBase currentContent;
    
    public OptionViewModel(
        SideMenuViewModel sideMenu, 
        INavigationService navigation, 
        BookingCheckoutSearchViewModel searchVm, 
        IBookingService bookingService,
        IOptionService optionService)
    {
        SideMenu = sideMenu;
        _navigation = navigation;
        _bookingService = bookingService;
        _optionService = optionService;
        
        searchVm.SearchSucceeded += bookings =>
        {
            var bookingOptionVm = new BookingForOptionViewModel(
                 bookings,
                 optionService,
                "Ajouter");
            
            CurrentContent = bookingOptionVm;
        };
        
        CurrentContent = searchVm;
    }
}