using System.Diagnostics.Metrics;
using System.Net;
using System.Net.Http.Json;

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
        
        switch (response.StatusCode)
        {
            case HttpStatusCode.OK:
            case HttpStatusCode.Created:
            {
                BookingResponse? booking = await response.Content
                    .ReadFromJsonAsync<BookingResponse>();
                
                return new ApiResult<BookingResponse>(
                    true,
                    booking,
                    null
                );
            }

            case HttpStatusCode.Conflict:
            case HttpStatusCode.Unauthorized:
            case HttpStatusCode.Forbidden:
            {
                var message =  await response.Content.ReadAsStringAsync();
                return new ApiResult<BookingResponse>(
                    false,
                    null,
                    message
                );
            }

            default:
            {
                return new ApiResult<BookingResponse>(
                    false,
                    null,
                    "Erreur de connexion à l'API"
                );
            }
        }
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
        
        switch (response.StatusCode)
        {
            case HttpStatusCode.OK:
            case HttpStatusCode.Created:
            {
                BookingResponse? booking = await response.Content
                    .ReadFromJsonAsync<BookingResponse>();
                
                return new ApiResult<BookingResponse>(
                    true,
                    booking,
                    null
                );
            }

            case HttpStatusCode.Conflict:
            case HttpStatusCode.Unauthorized:
            case HttpStatusCode.Forbidden:
            {
                var message =  await response.Content.ReadAsStringAsync();
                return new ApiResult<BookingResponse>(
                    false,
                    null,
                    message
                );
            }

            default:
            {
                return new ApiResult<BookingResponse>(
                    false,
                    null,
                    "Erreur de connexion à l'API"
                );
            }
        }
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

        switch (response.StatusCode)
        {
            case HttpStatusCode.OK:
            {
                var bookings = await response.Content
                    .ReadFromJsonAsync<List<BookingResponse>>();

                return new ApiResult<List<BookingResponse>>(
                    true,
                    bookings,
                    null
                );
            }

            case HttpStatusCode.Unauthorized:
            case HttpStatusCode.Forbidden:
            case HttpStatusCode.NotFound:
            {
                var message = await response.Content.ReadAsStringAsync();

                return new ApiResult<List<BookingResponse>>(
                    false,
                    null,
                    message
                );
            }

            default:
            {
                return new ApiResult<List<BookingResponse>>(
                    false,
                    null,
                    "Erreur de connexion à l'API"
                );
            }
        }
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

        switch (response.StatusCode)
        {
            case HttpStatusCode.OK:
            {
                var bookings = await response.Content
                    .ReadFromJsonAsync<List<BookingResponse>>();

                return new ApiResult<List<BookingResponse>>(
                    true,
                    bookings,
                    null
                );
            }

            case HttpStatusCode.Unauthorized:
            case HttpStatusCode.Forbidden:
            case HttpStatusCode.NotFound:
            {
                var message = await response.Content.ReadAsStringAsync();

                return new ApiResult<List<BookingResponse>>(
                    false,
                    null,
                    message
                );
            }

            default:
            {
                return new ApiResult<List<BookingResponse>>(
                    false,
                    null,
                    "Erreur de connexion à l'API"
                );
            }
        }
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
        
        switch (response.StatusCode)
        {
            case HttpStatusCode.OK:
            case HttpStatusCode.Created:
            {
                BookingResponse? booking = await response.Content
                    .ReadFromJsonAsync<BookingResponse>();
                
                return new ApiResult<BookingResponse>(
                    true,
                    booking,
                    null
                );
            }

            case HttpStatusCode.Conflict:
            case HttpStatusCode.Unauthorized:
            case HttpStatusCode.Forbidden:
            {
                var message =  await response.Content.ReadAsStringAsync();
                return new ApiResult<BookingResponse>(
                    false,
                    null,
                    message
                );
            }

            default:
            {
                return new ApiResult<BookingResponse>(
                    false,
                    null,
                    "Erreur de connexion à l'API"
                );
            }
        }
    }
}