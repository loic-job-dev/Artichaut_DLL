using System;
using System.Threading.Tasks;
using ArtichautDesktopApp.Mappers;
using ArtichautDesktopApp.Models;
using ArtichautDesktopApp.Services;
using ArtichautDesktopApp.ViewModels.Checkout;
using ArtichautLibrary.Services;
using CommunityToolkit.Mvvm.ComponentModel;

namespace ArtichautDesktopApp.ViewModels.Option;

public partial class OptionViewModel : ViewModelBase
{
    private readonly INavigationService _navigation;
    private  readonly IBookingService _bookingService;
    private readonly IOptionService _optionService;

    public SideMenuViewModel SideMenu { get; }
    
    [ObservableProperty]
    private ViewModelBase currentContent;
    
    public OptionViewModel(
        SideMenuViewModel sideMenu, 
        INavigationService navigation, 
        BookingCheckoutSearchViewModel searchVm, 
        IBookingService bookingService,
        IOptionService optionService)
    {
        SideMenu = sideMenu;
        _navigation = navigation;
        _bookingService = bookingService;
        _optionService = optionService;
        
        searchVm.SearchSucceeded += bookings =>
        {
            var bookingOptionVm = new BookingForOptionViewModel(
                 bookings,
                 optionService,
                "Ajouter");
            
            CurrentContent = bookingOptionVm;

            bookingOptionVm.SearchOptionsSucceeded += (booking, options) =>
            {
                var optionVm =
                    new OptionAdditionViewModel(booking, options);

                CurrentContent = optionVm;
                
                optionVm.OptionAdditionRequested += OnOptionAdditionRequested;

                CurrentContent = optionVm;
            };
            
        };
        
        CurrentContent = searchVm;
    }
    
    
    private async Task OnOptionAdditionRequested(
        Booking booking,
        Models.Option option,
        DateOnly from,
        DateOnly to)
    {
        var result =
            await _optionService.AddOptionToBooking(
                booking.Id.ToString(),
                option.Id.ToString(),
                from,
                to);

        if (!result.Success)
        {
            // afficher erreur
            return;
        }
        
        
        var updatedBooking =
            result.Data.ToModel();

        CurrentContent =
            new BookingSummaryViewModel(updatedBooking);
    }
}