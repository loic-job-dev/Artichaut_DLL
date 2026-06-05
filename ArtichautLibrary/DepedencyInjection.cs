using ArtichautLibrary.Helper;
using ArtichautLibrary.Providers;
using ArtichautLibrary.Services;

namespace ArtichautLibrary;

using Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Provides dependency injection extensions for the Artichaut client.
/// </summary>
public static class DependencyInjection
{
    
    /// <summary>
    /// Registers the Artichaut client and its services.
    /// </summary>
    /// <param name="services"> Service collection used to register dependencies. </param>
    /// <param name="baseUrl"> Base URL of the Artichaut API. </param>
    /// <returns>
    /// The updated service collection.
    /// </returns>
    public static IServiceCollection AddArtichautClient(
        this IServiceCollection services,
        string baseUrl)
    {
        // 1. Token global
        services.AddSingleton<ITokenProvider, TokenProvider>();

        // 2. Handler d’auth automatique
        services.AddTransient<AuthHeaderHandler>();

        // 3. HttpClient pour les services API
        services.AddHttpClient<IAuthService, AuthService>(client =>
            {
                client.BaseAddress = new Uri(baseUrl);
            })
            .AddHttpMessageHandler<AuthHeaderHandler>();

        services.AddHttpClient<IBookingService, BookingService>(client =>
            {
                client.BaseAddress = new Uri(baseUrl);
            })
            .AddHttpMessageHandler<AuthHeaderHandler>();

        services.AddHttpClient<IOptionService, OptionService>(client =>
            {
                client.BaseAddress = new Uri(baseUrl);
            })
            .AddHttpMessageHandler<AuthHeaderHandler>();

        // 4. Client principal
        services.AddHttpClient<ArtichautClient>(client =>
        {
            client.BaseAddress = new Uri(baseUrl);
        });

        return services;
    }
}