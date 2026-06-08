using System;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.DependencyInjection;

namespace ArtichautDesktopApp.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty]
    private ViewModelBase currentViewModel;
    
    public MainWindowViewModel(
        LoginViewModel loginVm,
        LandingViewModel landVm)
    {
        Console.WriteLine($"Subscribed to LandingVM {landVm.GetHashCode()}");
        
        loginVm.LoginSucceeded += OnLoginSucceeded;
        landVm.LogoutRequested += OnLogoutSucceeded;

        CurrentViewModel = loginVm;
    }

    private void OnLoginSucceeded()
    {
        CurrentViewModel = App.Services.GetRequiredService<LandingViewModel>();
    }

    private void OnLogoutSucceeded()
    {
        CurrentViewModel = App.Services.GetRequiredService<LoginViewModel>();
    }
}