namespace ArtichautLibrary.Services;

/// <summary>
/// Provides booking management operations against the Artichaut API.
/// </summary>
public interface IBookingService
{
    /// <summary>
    /// Creates a new booking.
    /// </summary>
    /// <param name="startBookedDate"> The start date of the booking. </param>
    /// <param name="endBookedDate"> The end date of the booking. </param>
    /// <param name="adultNumber"> The number of adults included in the booking. </param>
    /// <param name="childrenNumber"> The number of children included in the booking. </param>
    /// <param name="roomType"> The room type code to book. </param>
    /// <returns>
    /// An <see cref="ApiResult{T}"/> containing the created
    /// <see cref="BookingResponse"/>.
    /// </returns>
    Task<ApiResult<BookingResponse>> CreateBooking(
        DateOnly startBookedDate, 
        DateOnly endBookedDate, 
        int adultNumber, 
        int childrenNumber, 
        string roomType
        );
    
    /// <summary>
    /// Performs check-in for an existing booking.
    /// </summary>
    /// <param name="status"> The booking status given by the API before check-in. </param>
    /// <param name="startBookedDate"> The booking start date. </param>
    /// <param name="roomTypeId"> The unique identifier of the room type assigned to the booking. </param>
    /// <param name="bookingId"> The unique identifier of the booking to check in. </param>
    /// <returns>
    /// An <see cref="ApiResult{T}"/> containing the updated
    /// <see cref="BookingResponse"/>.
    /// </returns>
    Task<ApiResult<BookingResponse>> Checkin(
        string status,
        DateOnly startBookedDate,
        string roomTypeId,
        string bookingId
        );

    /// <summary>
    /// Retrieve the list of bookings for a given client with a BOOKED status.
    /// </summary>
    /// <param name="firstName"> The client's first name. </param>
    /// <param name="lastName"> The client's last name. </param>
    /// <returns>
    /// An <see cref="ApiResult{T}"/> containing the list of
    /// <see cref="BookingResponse"/> available for a check-in.
    /// </returns>
    Task<ApiResult<List<BookingResponse>>> GetBookingsToCheckinByClient(
        string firstName,
        string lastName
        );
    
    /// <summary>
    /// Retrieve the list of bookings for a given client with a CHECK_IN status.
    /// </summary>
    /// <param name="firstName"> The client's first name. </param>
    /// <param name="lastName"> The client's last name. </param>
    /// <returns>
    /// An <see cref="ApiResult{T}"/> containing the list of
    /// <see cref="BookingResponse"/> available for a check-out.
    /// </returns>
    Task<ApiResult<List<BookingResponse>>> GetBookingsToCheckoutByClient(
        string firstName,
        string lastName
    );

    /// <summary>
    /// Performs check-out for an existing booking.
    /// </summary>
    /// <param name="bookingId"></param>
    /// <returns></returns>
    Task<ApiResult<BookingResponse>> Checkout(
        string bookingId
    );
}