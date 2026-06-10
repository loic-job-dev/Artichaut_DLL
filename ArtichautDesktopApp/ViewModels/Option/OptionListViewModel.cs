using System.Collections.Generic;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace ArtichautDesktopApp.ViewModels.Option;

public partial class OptionListViewModel : ViewModelBase
{
    public ObservableCollection<OptionRowViewModel> Options { get; }
        = new();
    
    [ObservableProperty]
    private string errorMessage = "";

    public OptionListViewModel(
        IEnumerable<Models.Option> options)
    {
        foreach (var option in options)
        {
            Options.Add(
                new OptionRowViewModel(option.Description, this));
        }
    }
    public void SetError(string message)
    {
        ErrorMessage = message;
    }

    public void ClearError()
    {
        ErrorMessage = "";
    }
}