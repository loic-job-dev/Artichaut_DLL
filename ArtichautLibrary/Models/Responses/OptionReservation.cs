namespace ArtichautLibrary;

public record OptionReservation(
    Guid id,
    DateOnly startDate,
    DateOnly endDate,
    OptionResponse? option
    );