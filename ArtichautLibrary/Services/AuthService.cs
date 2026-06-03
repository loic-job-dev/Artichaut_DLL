using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace ArtichautLibrary.Services;

public class AuthService: IAuthService
{
    private readonly HttpClient _httpClient;

    public string? AccessToken { get; private set; }
    public AuthService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<AuthResponse?> Login(string username, string password)
    {
        var request = new LoginRequest(username, password);

        var response = await _httpClient.PostAsJsonAsync(
            "/auth/login",
            request
        );

        response.EnsureSuccessStatusCode();

        AuthResponse? auth = await response.Content
            .ReadFromJsonAsync<AuthResponse>();
        
        //Definition of the bearer token by default in headers
        if (auth?.AccessToken != null)
        {
            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue(
                    "Bearer",
                    auth.AccessToken
                );
            
            //recording the token, see later IMemoryCache
            AccessToken = auth.AccessToken;
        }
        
        return auth;
    }
    
    public void  Logout()
    {
        _httpClient.DefaultRequestHeaders.Authorization = null;
        AccessToken = null;
    }
}