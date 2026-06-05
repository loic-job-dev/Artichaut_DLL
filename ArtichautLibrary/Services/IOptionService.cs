namespace ArtichautLibrary.Services;

/// <summary>
/// Provides option management operations against the Artichaut API.
/// </summary>
public interface IOptionService
{
    /// <summary>
    /// Retrieves the list of available options.
    /// </summary>
    /// <returns>
    ///An <see cref="ApiResult{T}"/> containing the created
    /// <see cref="OptionResponse"/>.
    /// </returns>
    Task<ApiResult<List<OptionResponse>>> GetOptions();
}