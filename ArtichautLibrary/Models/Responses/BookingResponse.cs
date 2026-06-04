namespace ArtichautLibrary;

public record BookingResponse(
    string Id,
    DateOnly ValidationDate,
    DateOnly StartBookedDate,
    DateOnly EndBookedDate,
    int AdultNumber,
    int ChildrenNumber,
    int RoomUnitPrice,
    string Status,
    string Message
    );