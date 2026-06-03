using System;
using System.Threading.Tasks;
using ArtichautLibrary;
using Microsoft.Extensions.DependencyInjection;

namespace ArtichautConsoleApp;

class Program
{
    static async Task Main(string[] args)
    {
        var services = new ServiceCollection();

        services.AddArtichautClient(
            "http://localhost:8080"
        );

        var provider = services.BuildServiceProvider();

        var client = provider.GetRequiredService<ArtichautClient>();

        var auth = await client.Auth.Login(
            "rlame@artichaut.fr",
            "RaitournelleDeGalles"
        );

        string accessToken = auth.AccessToken;
        
        Console.WriteLine(accessToken);

        foreach (var role in auth.Roles)
        {
            Console.WriteLine(role);
        }
        
        client.Auth.Logout();
        
        // var authClient = await client.Auth.SignUp(
        //     "john.doe@test.com",
        //     "Password123!",
        //     "John",
        //     "Doe",
        //     "0612345678",
        //     "johndoe",
        //     12,
        //     "Rue",
        //     "de la Paix",
        //     null,
        //     "75001",
        //     "Paris"
        // );
        
        var authClient = await client.Auth.Login(
            "john.doe@test.com",
            "Password123!"
        );
        
        foreach (var role in authClient.Roles)
        {
            Console.WriteLine(role);
        }

        var booking = await client.Booking.CreateBooking(
        DateOnly.FromDateTime(DateTime.Now),
        DateOnly.FromDateTime(DateTime.Now.AddDays(2)),
        2, 
        0, 
        "STE");
        
        Console.WriteLine(booking);
    }
}