using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.RegularExpressions;
using ArtichautLibrary.Helper;
using ArtichautLibrary.Providers;

namespace ArtichautLibrary.Services;

public class AuthService: IAuthService
{
    private readonly HttpClient _httpClient;
    private readonly ITokenProvider _tokenProvider;

    public string? AccessToken { get; private set; }
    
    private static readonly Regex EmailRegex =
        new(@"^[^@\s]+@[^@\s]+\.[^@\s]+$",
            RegexOptions.Compiled);
    
    public AuthService(HttpClient httpClient, ITokenProvider tokenProvider)
    {
        _httpClient = httpClient;
        _tokenProvider = tokenProvider;
    }

    /// <summary>
    /// Authenticates a user against the Artichaut API.
    /// </summary>
    /// <remarks>
    /// On successful authentication, the JWT access token returned by the API
    /// is automatically stored and added as a Bearer token to the default
    /// HTTP request headers. Subsequent requests performed with this client
    /// will therefore be authenticated.
    /// </remarks>
    /// <param name="email"> Email address used to authenticate the user. </param>
    /// <param name="password"> Password associated with the user's account. </param>
    /// <returns>
    /// If successfully, an <see cref="AuthResponse"/> containing the authenticated user's
    /// information and access token if the authentication succeeds;
    /// otherwise the error message sent by the API.
    /// </returns>
    /// <exception cref="ArgumentException">
    /// Thrown when <paramref name="email"/> is not a valid email address.
    /// </exception>
    public async Task<ApiResult<AuthResponse>> Login(string email, string password)
    {
        if (!EmailRegex.IsMatch(email))
        {
            throw new ArgumentException(
                "Format d'email incorrect !",
                nameof(email));
        }
        
        var request = new LoginRequest(email, password);

        var response = await _httpClient.PostAsJsonAsync(
            "/auth/login",
            request
        );
        
        var result = await HandlerResponseHelper.HandlerResponse<AuthResponse>(response);

        // 🔥 token uniquement ici (logique métier)
        if (result.Success && result.Data?.AccessToken != null)
        {
            _tokenProvider.SetToken(result.Data.AccessToken);
        }

        return result;
    }
    
    /// <summary>
    /// Logs out the current user.
    /// </summary>
    /// <remarks>
    /// Removes the stored access token and clears the Authorization header
    /// from the underlying HTTP client. After calling this method,
    /// authenticated endpoints can no longer be accessed until
    /// <see cref="Login(string, string)"/> is called again.
    /// </remarks>
    public void  Logout()
    {
        _tokenProvider.SetToken(null);
    }

    /// <summary>
    /// Creates a new user account in the Artichaut API and authenticates the user.
    /// </summary>
    /// <remarks>
    /// On successful registration, the JWT access token returned by the API
    /// is automatically stored and added as a Bearer token to the default
    /// HTTP request headers. Subsequent requests performed with this client
    /// will therefore be authenticated.
    /// </remarks>
    /// <param name="email">Email address of the new user.</param>
    /// <param name="password"> Password of the new user. </param>
    /// <param name="firstName"> User's first name. </param>
    /// <param name="lastName"> User's last name. </param>
    /// <param name="phoneNumber"> User's phone number. </param>
    /// <param name="pseudo"> User's public username. </param>
    /// <param name="streetNumber"> Street number of the user's address. </param>
    /// <param name="streetType"> Street type (e.g. Street, Avenue, Boulevard). </param>
    /// <param name="streetName"> Street name of the user's address. </param>
    /// <param name="addressComplement"> Optional address complement. </param>
    /// <param name="zipCode"> Postal or ZIP code. </param>
    /// <param name="city"> City of residence. </param>
    /// <returns>
    /// If successfully, an <see cref="AuthResponse"/> containing the authenticated user's
    /// information and access token if the registration succeeds;
    /// otherwise the error message sent by the API.
    /// </returns>
    /// <exception cref="ArgumentException">
    /// Thrown when <paramref name="email"/> is not a valid email address.
    /// </exception>
    public async Task<ApiResult<AuthResponse>> SignUp(
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
        )
    {
        if (!EmailRegex.IsMatch(email))
        {
            throw new ArgumentException(
                "Format d'email incorrect !",
                nameof(email));
        }
        
        var request = new SignUpRequest(email, 
            password, 
            firstName, 
            lastName, 
            phoneNumber, 
            pseudo, 
            streetNumber,
            streetType, 
            streetName, 
            addressComplement, 
            zipCode, 
            city);
        
        var response = await _httpClient.PostAsJsonAsync(
            "/auth/signup",
            request
        );
        
        var auth = await response.Content
            .ReadFromJsonAsync<AuthResponse>();

        if (auth?.AccessToken != null)
        {
            _tokenProvider.SetToken(auth.AccessToken);
        }

        return await HandlerResponseHelper.HandlerResponse<AuthResponse>(response);
    }
}