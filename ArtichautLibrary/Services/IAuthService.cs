namespace ArtichautLibrary.Services;

public interface IAuthService
{
    Task<ApiResult<AuthResponse>> Login(string email, string password);
    
    void Logout();

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