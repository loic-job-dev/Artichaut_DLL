namespace ArtichautLibrary.Services;

public interface IAuthService
{
    Task<AuthResponse?> Login(string username, string password);
    
    void Logout();
}