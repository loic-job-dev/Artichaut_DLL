namespace ArtichautLibrary;

/// <summary>
/// Represents the result of an API operation.
/// </summary>
/// <typeparam name="T"> Type of data returned by the operation. </typeparam>
/// <param name="Success"> Indicates whether the operation completed successfully. </param>
/// <param name="Data"> Data returned by the API when the operation succeeds. </param>
/// <param name="ErrorMessage"> Error message returned when the operation fails. </param>
public record ApiResult<T>(
    bool Success,
    T? Data,
    string? ErrorMessage
    );