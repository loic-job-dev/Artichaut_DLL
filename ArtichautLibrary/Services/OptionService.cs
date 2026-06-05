using System.Net;
using System.Net.Http.Json;

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

        switch (response.StatusCode)
        {
            case HttpStatusCode.OK:
            {
                var options = await response.Content
                    .ReadFromJsonAsync<List<OptionResponse>>();

                return new ApiResult<List<OptionResponse>>(
                    true,
                    options,
                    null
                );
            }

            case HttpStatusCode.Unauthorized:
            case HttpStatusCode.Forbidden:
            case HttpStatusCode.NotFound:
            {
                var message = await response.Content.ReadAsStringAsync();

                return new ApiResult<List<OptionResponse>>(
                    false,
                    null,
                    message
                );
            }

            default:
            {
                return new ApiResult<List<OptionResponse>>(
                    false,
                    null,
                    "Erreur de connexion à l'API"
                );
            }
        }
    }
}