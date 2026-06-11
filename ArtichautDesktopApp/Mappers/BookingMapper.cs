using System.Linq;
using ArtichautDesktopApp.Models;
using ArtichautLibrary;

namespace ArtichautDesktopApp.Mappers;

public static class BookingMapper
{
    public static Booking ToModel(this BookingResponse response)
    {
        return new Booking
        {
            Id = response.Id,
            StartDate = response.StartBookedDate,
            EndDate = response.EndBookedDate,
            AdultCount = response.AdultNumber,
            ChildrenCount = response.ChildrenNumber,
            TotalPrice = response.FinalPrice ?? 0,
            Status = ParseStatus(response.Status),
            RoomTypes = (response.RoomTypes ?? [])
                .Select(x => x.ToModel())
                .ToList(),

            Rooms = (response.Rooms ?? [])
                .Select(x => x.ToModel())
                .ToList(),
            
            Options = response.Options
                .Select(x => x.ToModel())
                .Where(x => x != null)
                .Cast<Option>()
                .ToList(),
        };
    }

    private static BookingStatus ParseStatus(string status)
    {
        return status switch
        {
            "BOOKED" => BookingStatus.BOOKED,
            "CHECK_IN" => BookingStatus.CHECK_IN,
            "CHECK_OUT" => BookingStatus.CHECK_OUT,
            "CANCELLED" => BookingStatus.CANCELLED,
            _ => BookingStatus.UNKNOWN
        };
    }
    
    public static Booking ToBooking(this BookingCheckout checkout)
    {
        return new Booking
        {
            Id = checkout.Id,
            StartDate = checkout.StartDate,
            EndDate = checkout.EndDate,
            AdultCount = checkout.AdultCount,
            ChildrenCount = checkout.ChildrenCount,
            TotalPrice = checkout.TotalPrice,
            Rooms = checkout.Rooms,
            RoomTypes = checkout.RoomTypes
        };
    }
}