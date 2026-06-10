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
        _navigation.NavigateTo<CheckoutViewModel>();
    }

    [RelayCommand]
    private void GoToOption()
    {
        _navigation.NavigateTo<OptionViewModel>();
    }

    [RelayCommand]
    private void Logout()
    {
        _authService.Logout();
        _navigation.NavigateTo<LoginViewModel>();
    }
}