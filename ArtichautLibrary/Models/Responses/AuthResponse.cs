namespace ArtichautLibrary;

/// <summary>
/// Represents the authentication response returned by the Artichaut API.
/// </summary>
/// <param name="AccessToken"> JWT access token used to authenticate API requests. </param>
/// <param name="RefreshToken"> Token used to obtain a new access token when the current one expires. </param>
/// <param name="UserId"> Unique identifier of the authenticated user. </param>
/// <param name="Roles"> Roles assigned to the authenticated user. </param>
public record AuthResponse(
    string AccessToken, 
    string RefreshToken, 
    Guid UserId, 
    string[] Roles
    );