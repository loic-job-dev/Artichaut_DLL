using System.Net.Http.Json;

namespace ArtichautLibrary.Services;

public class BookingService: IBookingService
{
    private readonly HttpClient _httpClient;
    
    public BookingService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

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

        response.EnsureSuccessStatusCode();

        BookingResponse? booking = await response.Content
            .ReadFromJsonAsync<BookingResponse?>();
        
        return booking;
    }
}