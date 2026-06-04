namespace ArtichautLibrary;

internal record CreateBookingRequest(
    DateOnly StartBookedDate, 
    DateOnly EndBookedDate, 
    int AdultNumber, 
    int ChildrenNumber, 
    string RoomType 
    );

