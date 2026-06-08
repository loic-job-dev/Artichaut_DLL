using CommunityToolkit.Mvvm.ComponentModel;

namespace ArtichautDesktopApp.ViewModels;

public partial class LandingViewModel: MainWindowViewModel
{
    [ObservableProperty] private string _token;

    public LandingViewModel(string anyResult)
    {
        _token = anyResult;
    }
}