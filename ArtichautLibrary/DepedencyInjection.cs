namespace ArtichautLibrary;

using Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddArtichautClient(
        this IServiceCollection services,
        string baseUrl)
    {
        services.AddHttpClient<ArtichautClient>(client => { client.BaseAddress = new Uri(baseUrl); });

        return services;
    }
}