namespace ArtichautLibrary;

public record OptionDateRequest(
    DateOnly StartDate,
    DateOnly EndDate,
    string Code
    );