namespace ArtichautLibrary.Providers;

public interface ITokenProvider
{
    string? GetToken();
    void SetToken(string token);
}