namespace ArtichautLibrary;

public record BookingCheckoutOptionResponse(
    Guid id,
    DateOnly startDate,
    DateOnly endDate,
    string optionName,
    string optionDescription,
    int unitPrice
);