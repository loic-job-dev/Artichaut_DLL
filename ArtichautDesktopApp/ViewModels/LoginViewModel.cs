using System;
using System.Threading.Tasks;
using ArtichautDesktopApp.Services;
using ArtichautLibrary.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ArtichautDesktopApp.ViewModels;

public partial class LoginViewModel : ViewModelBase
{
    private  readonly IAuthService _authService;
    private readonly INavigationService _navigation;
    
    public LoginViewModel(IAuthService authService, INavigationService navigation)
    {
        _authService = authService;
        _navigation = navigation;
    }
    
    [ObservableProperty]
    private string email = "";

    [ObservableProperty]
    private string password = "";

    [ObservableProperty]
    private string errorMessage = "";

    [RelayCommand]
    private async Task Login()
    {
        var result = await _authService.Login(Email, Password);
        
        if (result.Success)
        {
            ErrorMessage = "OK";
            _navigation.NavigateTo<LandingViewModel>();
        }
        else
        {
            ErrorMessage = result.ErrorMessage;
        }
    }
}