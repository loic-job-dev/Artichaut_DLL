using ArtichautDesktopApp.Models;
using ArtichautDesktopApp.ViewModels.Option;
using ArtichautLibrary;

namespace ArtichautDesktopApp.Mappers;

public static class BookingOptionMapper
{
    public static BookingOption ToModel(
        this BookingCheckoutOptionResponse response)
    {
        return new BookingOption
        {
            Id = response.id,
            Name = response.optionName,
            Description = response.optionDescription,
            StartDate = response.startDate,
            EndDate = response.endDate,
            UnitPrice = response.unitPrice
        };
    }
}