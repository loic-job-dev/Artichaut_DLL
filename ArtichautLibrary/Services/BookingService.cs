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
    public async Task<BookingResponse?> CreateBooking(DateOnly startBookedDate,
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
                return await response.Content
                    .ReadFromJsonAsync<BookingResponse>();
            }

            case HttpStatusCode.Conflict:
            {
                var message =  await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Conflit de réservation : {message}");
                return null;
            }

            case HttpStatusCode.Unauthorized:
            {
                Console.WriteLine("Non authentifié");
                return null;
            }

            case HttpStatusCode.Forbidden:
            {
                Console.WriteLine("Accès interdit");
                return null;
            }

            default:
            {
                Console.WriteLine(
                    $"Erreur HTTP {(int)response.StatusCode}");
                return null;
            }
        }
    }
}