using System;
using ArtichautDesktopApp.Services;
using ArtichautLibrary.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ArtichautDesktopApp.ViewModels;

public partial class SideMenuViewModel : ObservableObject
{
    private  readonly IAuthService _authService;
    private readonly INavigationService _navigation;
    
    public SideMenuViewModel(IAuthService authService, INavigationService navigation)
    {
        _authService = authService;
        _navigation = navigation;
    }
    
    [RelayCommand]
    private void GoToCheckIn()
    {
        _navigation.NavigateTo<CheckinViewModel>();
    }

    [RelayCommand]
    private void GoToCheckOut()
    {
    }

    [RelayCommand]
    private void GoToAddOption()
    {
    }

    [RelayCommand]
    private void Logout()
    {
        Console.WriteLine("Logout clicked");
        _authService.Logout();
        _navigation.NavigateTo<LoginViewModel>();
    }
}