using System.Net;
using System.Net.Http.Json;

namespace ArtichautLibrary.Helper;

public class HandlerResponseHelper
{
    /// <summary>
    /// Helper method to handle the API response, and retrieve
    /// its data or its error message. Usefully in all the Services classes.
    /// </summary>
    /// <param name="response"> The HttpResponseMessage sent by the API. </param>
    /// <typeparam name="T"> The record required by the Service method. </typeparam>
    /// <returns>
    /// An <see cref="ApiResult{T}"/> containing the created
    /// the correct response record when successful; otherwise
    /// an error message.
    /// </returns>
    public static async Task<ApiResult<T>> HandlerResponse<T> (HttpResponseMessage response)
    {
        switch (response.StatusCode)
        {
            case HttpStatusCode.OK:
            case HttpStatusCode.Created:
            {
                //PROD
                T? data = await response.Content
                    .ReadFromJsonAsync<T>();
                
                //DEBUG API RESPONSE
                // var json = await response.Content.ReadAsStringAsync();
                //
                // Console.WriteLine("=== JSON API ===");
                // Console.WriteLine(json);
                // Console.WriteLine("================");
                //
                // T? data = System.Text.Json.JsonSerializer.Deserialize<T>(
                //     json,
                //     new System.Text.Json.JsonSerializerOptions
                //     {
                //         PropertyNameCaseInsensitive = true
                //     });
                
               return new ApiResult<T>(
                    true,
                    data,
                    null
                );
            }

            case HttpStatusCode.Conflict:
            case HttpStatusCode.Unauthorized:
            case HttpStatusCode.Forbidden:
            case HttpStatusCode.NotFound:  
            case HttpStatusCode.BadRequest:
            {
                var message =  await response.Content.ReadAsStringAsync();
                return new ApiResult<T>(
                    false,
                    default,
                    message
                );
            }

            default:
            {
                return new ApiResult<T>(
                    false,
                    default,
                    "Erreur de connexion à l'API"
                );
            }
        }
    }
}