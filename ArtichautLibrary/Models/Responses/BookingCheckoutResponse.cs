namespace ArtichautLibrary;

public record BookingCheckoutResponse(
    Guid Id,
    DateOnly ValidationDate,
    DateOnly StartBookedDate,
    DateOnly EndBookedDate,
    DateTime? DateCheckin,
    DateTime? DateCheckout,
    int AdultNumber,
    int ChildrenNumber,
    int RoomUnitPrice,
    string Status,
    List<RoomTypeResponse>? RoomTypes,
    List<RoomResponse>? Rooms,
    List<BookingCheckoutOptionResponse>? Options,
    int? FinalPrice
);