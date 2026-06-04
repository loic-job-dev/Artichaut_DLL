namespace ArtichautLibrary;

/// <summary>
/// Represents a booking returned by the Artichaut API.
/// </summary>
/// <param name="Id"> Unique identifier of the booking. </param>
/// <param name="ValidationDate"> Date on which the booking was validated. </param>
/// <param name="StartBookedDate"> Start date of the booking. </param>
/// <param name="EndBookedDate"> End date of the booking. </param>
/// <param name="AdultNumber"> Number of adults included in the booking. </param>
/// <param name="ChildrenNumber"> Number of children included in the booking. </param>
/// <param name="RoomUnitPrice"> Price per room unit. </param>
/// <param name="Status"> Current booking status. </param>
/// <param name="RoomTypes"> Collection of room types associated with the booking. </param>
public record BookingResponse(
    Guid Id,
    DateOnly ValidationDate,
    DateOnly StartBookedDate,
    DateOnly EndBookedDate,
    int AdultNumber,
    int ChildrenNumber,
    int RoomUnitPrice,
    string Status,
    List<RoomTypeResponse> RoomTypes
    );