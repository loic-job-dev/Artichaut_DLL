using System.Collections.ObjectModel;

namespace ArtichautDesktopApp.ViewModels.Option;

public class OptionListViewModel : ViewModelBase
{
    public ObservableCollection<OptionRowViewModel> Options { get; }
        = new();

    public OptionListViewModel()
    {
        Options.Add(new OptionRowViewModel("Petit déjeuner"));
        Options.Add(new OptionRowViewModel("Spa"));
        Options.Add(new OptionRowViewModel("Massage"));
    }
}