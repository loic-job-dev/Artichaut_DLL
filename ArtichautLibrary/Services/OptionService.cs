using System.Net;
using System.Net.Http.Json;
using ArtichautLibrary.Helper;

namespace ArtichautLibrary.Services;

public class OptionService: IOptionService
{
    private readonly HttpClient _httpClient;
    
    public OptionService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    /// <summary>
    /// Retrieves the list of available options.
    /// </summary>
    /// <returns>
    /// An <see cref="ApiResult{T}"/> containing the created
    /// <see cref="OptionResponse"/> when successful; otherwise
    /// an error message.
    /// </returns>
    public async Task<ApiResult<List<OptionResponse>>> GetOptions()
    {
        var url = "/options";

        var response = await _httpClient.GetAsync(url);

        return await HandlerResponseHelper.HandlerResponse<List<OptionResponse>>(response);
    }

    /// <summary>
    /// Add an option to a booking.
    /// </summary>
    /// <param name="bookingId"> The unique identifier of the booking. </param>
    /// <param name="optionId"> The unique identifier of the option. </param>
    /// <param name="startDate"> The date  when the option begins. </param>
    /// <param name="endDate"> The date  when the option ends. </param>
    /// <param name="code"> The optional code to apply a discount. </param>
    /// <returns>
    /// An <see cref="ApiResult{T}"/> containing the created
    /// <see cref="BookingResponse"/> when successful; otherwise
    /// an error message.
    /// </returns>
    public async Task<ApiResult<BookingResponse>> AddOptionToBooking(
        string bookingId,
        string optionId,
        DateOnly startDate,
        DateOnly endDate,
        string code = "")
    {
        OptionDateRequest request = new OptionDateRequest(startDate, endDate, code);
        
        var url = $"/bookings/{bookingId}/addOption/{optionId}";
        
        var response = await _httpClient.PutAsJsonAsync(
            url,
            request
        );
        
        return await HandlerResponseHelper.HandlerResponse<BookingResponse>(response);
    }
}