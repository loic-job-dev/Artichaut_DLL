namespace ArtichautLibrary.Services;

public interface IBookingService
{
    Task<BookingResponse?> CreateBooking(DateOnly startBookedDate, 
        DateOnly endBookedDate, 
        int adultNumber, 
        int childrenNumber, 
        string roomType );
}