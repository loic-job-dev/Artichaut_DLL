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
    
    /// <summary>
    /// Provides access to authentication operations.
    /// </summary>
    public IAuthService Auth { get; }
    
    /// <summary>
    /// Provides access to booking operations.
    /// </summary>
    public IBookingService Booking { get; }
    
    /// <summary>
    /// Provides access to options operations.
    /// </summary>
    public IOptionService Option { get; }

    public ArtichautClient(HttpClient httpClient, 
        IAuthService auth, 
        IBookingService booking, 
        IOptionService option)
    {
        Auth = auth;
        Booking = booking;
        Option = option;
    }
}