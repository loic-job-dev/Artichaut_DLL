using System;
using ArtichautDesktopApp.ViewModels;

namespace ArtichautDesktopApp.Services;

public interface INavigationService
{
    ViewModelBase CurrentViewModel { get; }

    event Action<ViewModelBase>? CurrentChanged;

    void NavigateTo<TViewModel>()
        where TViewModel : ViewModelBase;
}