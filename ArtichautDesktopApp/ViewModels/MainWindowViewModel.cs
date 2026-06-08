namespace ArtichautDesktopApp.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    private ViewModelBase _currentView;
    
    public LoginViewModel LoginVm { get; }
    public MainWindowViewModel(LoginViewModel loginVm)
    {
        LoginVm = loginVm;
    }
    
     public ViewModelBase CurrentView
    {
        get => _currentView;
        set => SetProperty(ref _currentView, value);
    }
}