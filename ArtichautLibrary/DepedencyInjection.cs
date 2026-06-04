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
        services.AddHttpClient<ArtichautClient>(client => { client.BaseAddress = new Uri(baseUrl); });

        return services;
    }
}