using ArtichautLibrary.Services;

namespace ArtichautLibrary;

public class ArtichautClient
{
    private readonly HttpClient _httpClient;
    
    public AuthService Auth { get; }
    public BookingService Booking { get; }

    public ArtichautClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
        Auth = new AuthService(httpClient);
        Booking = new BookingService(httpClient);
    }
}