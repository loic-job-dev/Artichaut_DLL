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

        if (authClient.Success)
        {
            foreach (var role in authClient.Data.Roles)
            {
                Console.WriteLine(role);
            }
        }
        else
        {
            Console.WriteLine(authClient.ErrorMessage);
        }

        // var result = await client.Booking.CreateBooking(
        // DateOnly.FromDateTime(DateTime.Now),
        // DateOnly.FromDateTime(DateTime.Now.AddDays(2)),
        // 2, 
        // 0, 
        // "STD");
        //
        // //Test for checkin
        // string status = result.Data.Status;
        // DateOnly startBookedDate = result.Data.StartBookedDate;
        // var bookingIg = result.Data.Id.ToString();
        // var roomTypeId = result.Data.RoomTypes.First().Id.ToString();
        //
        // if (result.Success)
        // {
        //     
        // }
        // else
        // {
        //     Console.WriteLine(result.ErrorMessage);
        // }
        
        client.Auth.Logout();
        
        var auth = await client.Auth.Login(
            "rlame@artichaut.fr",
            "RaitournelleDeGalles"
        );
        
        if (auth.Success)
        {
            Console.WriteLine(auth.Data.UserId);
        } 
        else
        {
            Console.WriteLine(auth.ErrorMessage);
        }
        
        // var checkin = await client.Booking.Checkin(
        //     status,
        //     startBookedDate,
        //     roomTypeId,
        //     bookingIg);
        //
        // if (checkin.Success)
        // {
        //     Console.WriteLine(checkin.Data);
        // }
        // else
        // {
        //     Console.WriteLine(checkin.ErrorMessage);
        // }

        var bookingsToCheckin = await client.Booking.GetBookingsToCheckinByClient("John", "Doe");

        if (bookingsToCheckin.Success)
        {
            foreach (var booking in bookingsToCheckin.Data)
            {
                Console.WriteLine($"Id de la réservation : {booking.Id}");
                Console.WriteLine($"Id du type de chambre : {booking.RoomTypes[0].Id}");
                Console.WriteLine($"Statut de la réservation : {booking.Status}\n");
            }
        }
        else
        {
            Console.WriteLine(bookingsToCheckin.ErrorMessage);
        }
        
        
        var bookingsToCheckout = await client.Booking.GetBookingsToCheckoutByClient("John", "Doe");

        if (bookingsToCheckin.Success)
        {
            foreach (var booking in bookingsToCheckout.Data)
            {
                Console.WriteLine($"Id de la réservation : {booking.Id}");
                Console.WriteLine($"Id du type de chambre : {booking.RoomTypes[0].Id}");
                Console.WriteLine($"Statut de la réservation : {booking.Status}\n");
            }
        }
        else
        {
            Console.WriteLine(bookingsToCheckin.ErrorMessage);
        }
    }
}