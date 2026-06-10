using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ArtichautDesktopApp.ViewModels.Option;

public class OptionListViewModel : ViewModelBase
{
    public ObservableCollection<OptionRowViewModel> Options { get; }
        = new();

    public OptionListViewModel(
        IEnumerable<Models.Option> options)
    {
        foreach (var option in options)
        {
            Options.Add(
                new OptionRowViewModel(option.Description));
        }
    }
}