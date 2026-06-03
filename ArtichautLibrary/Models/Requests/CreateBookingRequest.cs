namespace ArtichautLibrary;

public record CreateBookingRequest(
    DateOnly startBookedDate, 
    DateOnly endBookedDate, 
    int adultNumber, 
    int childrenNumber, 
    string roomType 
    );

