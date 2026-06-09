using System;
using ArtichautDesktopApp.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.DependencyInjection;

namespace ArtichautDesktopApp.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty]
    private ViewModelBase currentViewModel;
    
    public MainWindowViewModel(INavigationService navigation)
    {
        navigation.CurrentChanged += vm =>
            CurrentViewModel = vm;

        navigation.NavigateTo<LoginViewModel>();
    }
}