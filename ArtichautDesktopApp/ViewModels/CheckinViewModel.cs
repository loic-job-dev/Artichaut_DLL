using ArtichautDesktopApp.Services;

namespace ArtichautDesktopApp.ViewModels;

public class CheckinViewModel : ViewModelBase
{
    private readonly INavigationService _navigation;

    public SideMenuViewModel SideMenu { get; }

    public CheckinViewModel(SideMenuViewModel sideMenu, INavigationService navigation)
    {
        SideMenu = sideMenu;
        _navigation = navigation;
    }
    
}