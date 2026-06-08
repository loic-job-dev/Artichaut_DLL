using System;
using CommunityToolkit.Mvvm.Input;

namespace ArtichautDesktopApp.ViewModels;

public partial class LandingViewModel : ViewModelBase
{
    public event Action? LogoutRequested;

    private readonly SideMenuViewModel _sideMenu;

    public LandingViewModel(
        SideMenuViewModel sideMenu)
    {
        Console.WriteLine($"LandingVM {GetHashCode()}");

        _sideMenu = sideMenu;

        _sideMenu.LogoutSucceeded += () =>
        {
            Console.WriteLine($"Logout relayed by {GetHashCode()}");
            LogoutRequested?.Invoke();
        };
    }

    public SideMenuViewModel SideMenu => _sideMenu;
}