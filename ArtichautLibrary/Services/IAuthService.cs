namespace ArtichautLibrary.Services;

/// <summary>
/// Provides authentication operations against the Artichaut API.
/// </summary>
public interface IAuthService
{
    
    /// <summary>
    /// Authenticates a user and stores the access token for future requests.
    /// </summary>
    /// <param name="email">The user's email address.</param>
    /// <param name="password">The user's password.</param>
    /// <returns>
    /// An <see cref="ApiResult{T}"/> containing the authenticated user.
    /// </returns>
    Task<ApiResult<AuthResponse>> Login(string email, string password);
    
    /// <summary>
    /// Logs out a user : deletes the access token given by the Login or SignUp method
    /// </summary>
    void Logout();

    /// <summary>
    /// Creates a new user account, authenticates the user,
    /// and stores the access token for future requests.
    /// </summary>
    /// <param name="email">The user's email address.</param>
    /// <param name="password">The user's password.</param>
    /// <param name="firstName">The user's first name.</param>
    /// <param name="lastName">The user's last name.</param>
    /// <param name="phoneNumber">The user's phone number.</param>
    /// <param name="pseudo">The user's public username.</param>
    /// <param name="streetNumber">The street number of the user's address.</param>
    /// <param name="streetType">The street type (Street, Avenue, Boulevard, etc.).</param>
    /// <param name="streetName">The street name.</param>
    /// <param name="addressComplement"> Additional address information such as apartment, building, or floor. </param>
    /// <param name="zipCode">The postal code.</param>
    /// <param name="city">The city name.</param>
    /// <returns>
    /// An <see cref="ApiResult{T}"/> containing the authenticated user.
    /// </returns>
    Task<ApiResult<AuthResponse>> SignUp(
        string email,
        string password,
        string firstName,
        string lastName,
        string phoneNumber,
        string pseudo,
        int streetNumber,
        string streetType,
        string streetName,
        string? addressComplement,
        string zipCode,
        string city
    );
}