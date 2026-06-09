using System;
using ArtichautDesktopApp.Services;
using CommunityToolkit.Mvvm.Input;

namespace ArtichautDesktopApp.ViewModels;

public partial class LandingViewModel : ViewModelBase
{
    private readonly INavigationService _navigation;

    public SideMenuViewModel SideMenu { get; }
    
    public LandingViewModel(
        SideMenuViewModel sideMenu, 
        INavigationService navigation)
    {
        SideMenu = sideMenu;
        _navigation = navigation;
    }
}