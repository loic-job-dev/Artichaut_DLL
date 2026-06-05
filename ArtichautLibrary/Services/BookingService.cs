using System.Diagnostics.Metrics;
using System.Net;
using System.Net.Http.Json;
using ArtichautLibrary.Helper;

namespace ArtichautLibrary.Services;

public class BookingService: IBookingService
{
    private readonly HttpClient _httpClient;
    
    public BookingService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    /// <summary>
    /// Creates a new booking.
    /// </summary>
    /// <param name="startBookedDate"> Start date of the booking. </param>
    /// <param name="endBookedDate"> End date of the booking. </param>
    /// <param name="adultNumber"> Number of adults. </param>
    /// <param name="childrenNumber"> Number of children. </param>
    /// <param name="roomType"> Room type code. </param>
    /// <returns>
    /// An <see cref="ApiResult{T}"/> containing the created
    /// <see cref="BookingResponse"/> when successful; otherwise
    /// an error message.
    /// </returns>
    public async Task<ApiResult<BookingResponse>> CreateBooking(
        DateOnly startBookedDate,
        DateOnly endBookedDate,
        int adultNumber,
        int childrenNumber,
        string roomType)
    {
        var request = new CreateBookingRequest(startBookedDate, endBookedDate, adultNumber, childrenNumber, roomType);

        var response = await _httpClient.PostAsJsonAsync(
            "/bookings",
            request
        );
        
        return await HandlerResponseHelper.HandlerResponse<BookingResponse>(response);
    }

    /// <summary>
    /// Performs check-in for an existing booking.
    /// </summary>
    /// <param name="status"> Status of the booking. </param>
    /// <param name="startBookedDate"> Start date of the booking. </param>
    /// <param name="roomTypeId"> The unique identifier of the booked room type. </param>
    /// <param name="bookingId"> The unique identifier of the booking. </param>
    /// <returns>
    /// An <see cref="ApiResult{T}"/> containing the updated
    /// <see cref="BookingResponse"/> when successful; otherwise
    /// an error message.
    /// </returns>
    public async Task<ApiResult<BookingResponse>> Checkin(
        string status,
        DateOnly startBookedDate,
        string roomTypeId,
        string bookingId)
    {
        var request = new CheckinRequest(status, startBookedDate, roomTypeId);

        var response = await _httpClient.PutAsJsonAsync(
            $"/bookings/{bookingId}/checkin",
            request
        );

        return await HandlerResponseHelper.HandlerResponse<BookingResponse>(response);
    }

    /// <summary>
    /// Retrieve the list of bookings for a given client with a BOOKED status.
    /// </summary>
    /// <param name="firstName"> The client's first name. </param>
    /// <param name="lastName"> The client's last name. </param>
    /// <returns>
    /// An <see cref="ApiResult{T}"/> containing the list of
    /// <see cref="BookingResponse"/> available for a check-in when successful; otherwise
    /// an error message.
    /// </returns>
    public async Task<ApiResult<List<BookingResponse>>> GetBookingsToCheckinByClient(
        string firstName,
        string lastName
    )
    {
        var url = $"/bookings/bookingToCheckin?firstName={firstName}&lastName={lastName}";

        var response = await _httpClient.GetAsync(url);

        return await HandlerResponseHelper.HandlerResponse<List<BookingResponse>>(response);
    }

    /// <summary>
    /// Retrieve the list of bookings for a given client with a CHECK_IN status.
    /// </summary>
    /// <param name="firstName"> The client's first name. </param>
    /// <param name="lastName"> The client's last name. </param>
    /// <returns>
    /// An <see cref="ApiResult{T}"/> containing the list of
    /// <see cref="BookingResponse"/> available for a check-out when successful; otherwise
    /// an error message.
    /// </returns>
    public async Task<ApiResult<List<BookingResponse>>> GetBookingsToCheckoutByClient(
        string firstName,
        string lastName
    )
    {
        var url = $"/bookings/bookingToCheckout?firstName={firstName}&lastName={lastName}";

        var response = await _httpClient.GetAsync(url);

        return await HandlerResponseHelper.HandlerResponse<List<BookingResponse>>(response);
    }
    
    /// <summary>
    /// Performs check-out for an existing booking.
    /// </summary>
    /// <param name="bookingId"></param>
    /// <returns>
    /// An <see cref="ApiResult{T}"/> containing the updated
    /// <see cref="BookingResponse"/> when successful; otherwise
    /// an error message.
    /// </returns>
    public async Task<ApiResult<BookingResponse>> Checkout(
        string bookingId
    )
    {
        var response = await _httpClient.PutAsync(
            $"/bookings/{bookingId}/checkout", null
        );
        
        return await HandlerResponseHelper.HandlerResponse<BookingResponse>(response);
    }
}