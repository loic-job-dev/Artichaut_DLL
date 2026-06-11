using System;
using System.Threading.Tasks;
using ArtichautDesktopApp.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ArtichautDesktopApp.ViewModels.Option;

public partial class OptionRowViewModel : ViewModelBase
{
    private readonly OptionListViewModel _parent;

    public Models.Option _option;
    public string OptionName { get; }

    [ObservableProperty]
    private string fromDate = "";

    [ObservableProperty]
    private string toDate = "";
    
    public event Action<OptionRowViewModel, DateOnly, DateOnly>? AddRequested;

    public OptionRowViewModel(Models.Option option, OptionListViewModel parent)
    {
        _option = option;
        _parent = parent;
        OptionName = _option.Name;
    }

    [RelayCommand]
    private Task AddOption()
    {
        _parent.ClearError();

        if (!DateOnly.TryParse(FromDate, out var from))
        {
            _parent.SetError(
                $"Date de début invalide pour l'option '{_option.Name}'.");
            return Task.CompletedTask;
        }

        if (!DateOnly.TryParse(ToDate, out var to))
        {
            _parent.SetError(
                $"Date de fin invalide pour l'option '{_option.Name}'.");
            return Task.CompletedTask;
        }

        if (to < from)
        {
            _parent.SetError(
                $"La date de fin doit être postérieure à la date de début.");
            return Task.CompletedTask;
        }

        AddRequested?.Invoke(this, from, to);

        return Task.CompletedTask;
        
        // Appel API
        // var result = await _optionService.AddOptionToBooking(
        //     Booking.Id,
        //     _option.Id,
        //     fromDate,
        //     toDate);
        //
        // if (result.Success)
        // {
        //     Console.WriteLine(result.Data.ToString());
        // }
        // else
        // {
        //     Console.WriteLine(result.ErrorMessage);
        // }
    }
}