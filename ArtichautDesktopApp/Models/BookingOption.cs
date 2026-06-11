using System;

namespace ArtichautDesktopApp.Models;

public class BookingOption
{
    public Guid Id { get; init; }

    public string Name { get; init; } = "";

    public string Description { get; init; } = "";

    public DateOnly StartDate { get; init; }

    public DateOnly EndDate { get; init; }

    public decimal UnitPrice { get; init; }
}