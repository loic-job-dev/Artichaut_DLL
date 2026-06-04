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
    /// The created booking if successful; otherwise null.
    /// </returns>
    public async Task<ApiResult<BookingResponse>> CreateBooking(DateOnly startBookedDate,
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
}