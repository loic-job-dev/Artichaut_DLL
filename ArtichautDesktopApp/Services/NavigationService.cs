using System;
using ArtichautDesktopApp.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace ArtichautDesktopApp.Services;

public class NavigationService : INavigationService
{
    private readonly IServiceProvider _services;

    public ViewModelBase CurrentViewModel { get; private set; }

    public event Action<ViewModelBase>? CurrentChanged;

    public NavigationService(IServiceProvider services)
    {
        _services = services;
    }

    public void NavigateTo<TViewModel>()
        where TViewModel : ViewModelBase
    {
        CurrentViewModel =
            _services.GetRequiredService<TViewModel>();

        CurrentChanged?.Invoke(CurrentViewModel);
    }
}