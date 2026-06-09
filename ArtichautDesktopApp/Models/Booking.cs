using System;
using System.Collections.Generic;

namespace ArtichautDesktopApp.Models;

public class Booking
{
    public Guid Id { get; init; }

    public DateOnly StartDate { get; init; }

    public DateOnly EndDate { get; init; }

    public int AdultCount { get; init; }

    public int ChildrenCount { get; init; }

    public decimal TotalPrice { get; init; }

    public BookingStatus Status { get; init; }

    public IReadOnlyList<RoomType> RoomTypes { get; init; } = [];
    public IReadOnlyList<Room> Rooms { get; init; } = [];
}