using System;
using ArtichautLibrary.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ArtichautDesktopApp.ViewModels;

public partial class SideMenuViewModel : ObservableObject
{
    private  readonly IAuthService _authService;
    
    public event Action? LogoutSucceeded;
    
    public SideMenuViewModel(IAuthService authService)
    {
        _authService = authService;
    }
    
    [RelayCommand]
    private void CheckIn()
    {
    }

    [RelayCommand]
    private void CheckOut()
    {
    }

    [RelayCommand]
    private void AddOption()
    {
    }

    [RelayCommand]
    private void Logout()
    {
        Console.WriteLine("Logout clicked");
        _authService.Logout();
        LogoutSucceeded?.Invoke();
    }
}