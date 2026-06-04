using ArtichautLibrary.Services;

namespace ArtichautLibrary;

public class ArtichautClient
{
    private readonly HttpClient _httpClient;
    
    public IAuthService Auth { get; }
    public IBookingService Booking { get; }

    public ArtichautClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
        Auth = new AuthService(httpClient);
        Booking = new BookingService(httpClient);
    }
}