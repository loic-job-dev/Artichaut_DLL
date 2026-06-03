namespace ArtichautLibrary;

public record AuthResponse(string AccessToken, string RefreshToken, string UserId, string[] Roles);