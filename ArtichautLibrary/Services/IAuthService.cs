namespace ArtichautLibrary.Services;

public interface IAuthService
{
    Task<AuthResponse?> Login(string email, string password);
    
    void Logout();
}