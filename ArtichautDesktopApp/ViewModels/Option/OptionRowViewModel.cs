using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ArtichautDesktopApp.ViewModels.Option;

public partial class OptionRowViewModel : ViewModelBase
{
    private readonly OptionListViewModel _parent;
    public string OptionName { get; }

    [ObservableProperty]
    private string fromDate = "";

    [ObservableProperty]
    private string toDate = "";

    public OptionRowViewModel(string optionName, OptionListViewModel parent)
    {
        OptionName = optionName;
        _parent = parent;
    }

    [RelayCommand]
    private void AddOption()
    {
        _parent.ClearError();

        if (!DateOnly.TryParse(FromDate, out var from))
        {
            _parent.SetError(
                $"Date de début invalide pour l'option '{OptionName}'.");
            return;
        }

        if (!DateOnly.TryParse(ToDate, out var to))
        {
            _parent.SetError(
                $"Date de fin invalide pour l'option '{OptionName}'.");
            return;
        }

        if (to < from)
        {
            _parent.SetError(
                $"La date de fin doit être postérieure à la date de début.");
            return;
        }

        // Appel API
    }
}