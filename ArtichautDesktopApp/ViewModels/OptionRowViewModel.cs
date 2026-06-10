using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ArtichautDesktopApp.ViewModels;

public partial class OptionRowViewModel : ViewModelBase
{
    public string OptionName { get; }

    [ObservableProperty]
    private string fromDate = "";

    [ObservableProperty]
    private string toDate = "";

    public OptionRowViewModel(string optionName)
    {
        OptionName = optionName;
    }

    [RelayCommand]
    private void AddOption()
    {
        // Appel API ici
    }
}