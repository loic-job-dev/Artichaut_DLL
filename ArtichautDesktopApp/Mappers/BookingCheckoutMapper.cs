using System.Linq;
using ArtichautDesktopApp.Models;
using ArtichautLibrary;

namespace ArtichautDesktopApp.Mappers;

public static class BookingCheckoutMapper
{
    public static BookingCheckout ToModel(
        this BookingCheckoutResponse response)
    {
        return new BookingCheckout
        {
            Id = response.Id,
            StartDate = response.StartBookedDate,
            EndDate = response.EndBookedDate,
            AdultCount = response.AdultNumber,
            ChildrenCount = response.ChildrenNumber,
            TotalPrice = response.FinalPrice ?? 0,

            Rooms = (response.Rooms ?? [])
                .Select(x => x.ToModel())
                .ToList(),

            RoomTypes = (response.RoomTypes ?? [])
                .Select(x => x.ToModel())
                .ToList(),

            Options = (response.Options ?? [])
                .Select(x => x.ToModel())
                .ToList()
        };
    }
}