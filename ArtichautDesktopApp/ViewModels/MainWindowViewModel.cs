using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.DependencyInjection;

namespace ArtichautDesktopApp.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty]
    private ViewModelBase currentViewModel;
    
    public MainWindowViewModel(LoginViewModel loginVm)
    {
        loginVm.LoginSucceeded += OnLoginSucceeded;

        CurrentViewModel = loginVm;
    }

    private void OnLoginSucceeded()
    {
        CurrentViewModel = App.Services.GetRequiredService<LandingViewModel>();
    }
}