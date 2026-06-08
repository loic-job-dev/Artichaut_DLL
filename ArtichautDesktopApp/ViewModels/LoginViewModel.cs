using System.Threading.Tasks;
using ArtichautLibrary.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ArtichautDesktopApp.ViewModels;

public partial class LoginViewModel : ViewModelBase
{
    private  readonly IAuthService _authService;
    
    public LoginViewModel(IAuthService authService)
    {
        _authService = authService;
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
        }
        else
        {
            ErrorMessage = result.ErrorMessage;
        }
    }
}