using ArtichautLibrary.Services;

namespace ArtichautLibrary;

/// <summary>
/// Main entry point for interacting with the Artichaut API.
/// </summary>
/// <remarks>
/// This client provides access to authentication and booking services.
/// </remarks>
public class ArtichautClient
{
    private readonly HttpClient _httpClient;
    
    /// <summary>
    /// Provides access to authentication operations.
    /// </summary>
    public IAuthService Auth { get; }
    
    /// <summary>
    /// Provides access to booking operations.
    /// </summary>
    public IBookingService Booking { get; }

    public ArtichautClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
        Auth = new AuthService(httpClient);
        Booking = new BookingService(httpClient);
    }
}