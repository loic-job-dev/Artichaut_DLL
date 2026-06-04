namespace ArtichautLibrary;

public record ApiResult<T>(
    bool Success,
    T? Data,
    string? ErrorMessage
);