namespace ArtichautLibrary;

public record BookingResponse(
    string id,
    DateOnly validationDate,
    DateOnly startBookedDate,
    DateOnly endBookedDate,
    int adultNumber,
    int childrenNumber,
    int roomUnitPrice,
    string status
    );