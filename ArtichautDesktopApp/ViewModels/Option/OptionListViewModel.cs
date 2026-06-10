using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace ArtichautDesktopApp.ViewModels.Option;

public partial class OptionListViewModel : ViewModelBase
{
    public ObservableCollection<OptionRowViewModel> Options { get; }
        = new();
    
    public event Action<Models.Option, DateOnly, DateOnly>? OptionSelected;
    
    [ObservableProperty]
    private string errorMessage = "";

    public OptionListViewModel(
        IEnumerable<Models.Option> options)
    {
        foreach (var option in options)
        {
            var vm = new OptionRowViewModel(option, this);

            vm.AddRequested += (_, from, to) =>
            {
                OptionSelected?.Invoke(option, from, to);
            };

            Options.Add(vm);
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