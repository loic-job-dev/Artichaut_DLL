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
    
    /// <summary>
    /// Add an option to a booking.
    /// </summary>
    /// <param name="bookingId"> The unique identifier of the booking. </param>
    /// <param name="optionId"> The unique identifier of the option. </param>
    /// <param name="startDate"> The date  when the option begins. </param>
    /// <param name="endDate"> The date  when the option ends. </param>
    /// <param name="code"> The optional code to apply a discount. </param>
    /// <returns>
    ///An <see cref="ApiResult{T}"/> containing the created
    /// <see cref="BookingResponse"/>.
    /// </returns>
    Task<ApiResult<BookingCheckoutResponse>> AddOptionToBooking(
        string bookingId,
        string optionId,
        DateOnly startDate,
        DateOnly endDate,
        string code = "");
}