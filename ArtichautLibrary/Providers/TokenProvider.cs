namespace ArtichautLibrary.Providers;

public class TokenProvider : ITokenProvider
{
    private string? _token;

    public string? GetToken() => _token;

    public void SetToken(string token)
    {
        _token = token;
    }
}