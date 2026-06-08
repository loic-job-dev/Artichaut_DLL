using CommunityToolkit.Mvvm.ComponentModel;

namespace ArtichautDesktopApp.ViewModels;

public partial class LoginViewModel: MainWindowViewModel
{
    [ObservableProperty] private string _errorMessage;

    public LoginViewModel(string anyResult)
    {
        _errorMessage = anyResult;
    }
}