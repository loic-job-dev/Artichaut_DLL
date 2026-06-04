namespace ArtichautLibrary;

/// <summary>
/// Represents a booking returned by the Artichaut API.
/// </summary>
/// <param name="Id"> Unique identifier of the booking. </param>
/// <param name="ValidationDate"> Date on which the booking was validated. </param>
/// <param name="StartBookedDate"> Start date of the booking. </param>
/// <param name="EndBookedDate"> End date of the booking. </param>
/// <param name="DateCheckin"> Date on which the check-in was performed. </param>
/// <param name="DateCheckout"> Date on which the check-out was performed. </param>
/// <param name="AdultNumber"> Number of adults included in the booking. </param>
/// <param name="ChildrenNumber"> Number of children included in the booking. </param>
/// <param name="RoomUnitPrice"> Price per room unit. </param>
/// <param name="Status"> Current booking status. </param>
/// <param name="RoomTypes"> Collection of room types associated with the booking. </param>
/// <param name="FinalPrice"> Final price given by the API. </param>
public record BookingResponse(
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
    List<RoomTypeResponse> RoomTypes,
    int? FinalPrice
    );