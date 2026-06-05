# ArtichautConnect

ArtichautConnect is a .NET client library designed to simplify communication with the Artichaut REST API.

The library provides strongly-typed services for authentication, booking management, and other Artichaut API features while handling HTTP communication internally.

## Installation

Register the client in your dependency injection container:

```csharp
using ArtichautLibrary;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();

services.AddArtichautClient(
    "http://localhost:8080"
);

var provider = services.BuildServiceProvider();

var client = provider.GetRequiredService<ArtichautClient>();
```

## Authentication

Authenticate a user using the `Auth` service:

```csharp
var auth = await client.Auth.Login(
    "user@test.com",
    "StrongPassword123!"
);

if (auth.Success)
{
    Console.WriteLine(auth.Data.UserId);
} 
else
{
    Console.WriteLine(auth.ErrorMessage);
}
```

On successful authentication, the JWT access token is automatically stored and added to all subsequent requests.

### Logout

```csharp
client.Auth.Logout();
```

This removes the stored access token and clears the Authorization header.

## Create a Booking

```csharp
var result = await client.Booking.CreateBooking(
    DateOnly.FromDateTime(DateTime.Today),
    DateOnly.FromDateTime(DateTime.Today.AddDays(2)),
    2,
    0,
    "STE"
);

if (result.Success)
{
    Console.WriteLine(result.Data);
}
else
{
    Console.WriteLine(result.ErrorMessage);
}
```

This allows to display the error messages sent by the API in case of 409 status code by exemple.

## Retrieves the possible bookings to perform a check-in

```csharp
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
```

This method is necessary to obtain all the data before any check-in. The user must be logged with the correct role.

## Check-in

```csharp
var checkin = await client.Booking.Checkin(
             status,
             startBookedDate,
             roomTypeId,
             bookingIg
             );
        
if (checkin.Success)
{
    Console.WriteLine(checkin.Data);
}
else
{
    Console.WriteLine(checkin.ErrorMessage);
}
```

With the values given by the GetBookingsToCheckinByClient method, it is possible to perform a check-in.

## Retrieves the possible bookings to perform a check-out

```csharp
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
```

This method is necessary to obtain all the data before any check-out. The user must be logged with the correct role.

## Check-out

```csharp
var bookingCheckoutDone = await client.Booking.Checkout(bookingIdToCheckout);

if (bookingCheckoutDone.Success)
{
    Console.WriteLine($"Prix final de la réservation : {bookingCheckoutDone.Data.FinalPrice}");
}
else
{
    Console.WriteLine(bookingCheckoutDone.ErrorMessage);
}
```

With the value given by the GetBookingsToCheckoutByClient method, it is possible to perform a check-out .

## Retrieves ther list of available options

```csharp
var options = await client.Option.GetOptions();

if (options.Success)
{
    foreach (var option in options.Data)
    {
        Console.WriteLine($"{option.Name} : {option.Description}\nId de l'option : {option.Id}\n");
    }
}
else
{
    Console.WriteLine(options.ErrorMessage);
}
```

This method is necessary to obtain all the data before adding an option to a booking.

## Add an option to a booking

```csharp
var optionIdToAdd = "";

Console.WriteLine("Entrez l'Id de l'option à ajouter :");
optionIdToAdd = Console.ReadLine();

var bookingWithNewOption = await client.Option.AddOptionToBooking(
    bookingIg,
    optionIdToAdd,
    DateOnly.FromDateTime(DateTime.Now),
    DateOnly.FromDateTime(DateTime.Now));

if (bookingWithNewOption.Success)
{
    Console.WriteLine(bookingWithNewOption.Data);
}
else
{
    Console.WriteLine(bookingWithNewOption.ErrorMessage);
};
```

This method allows a user with the correct role to add an aoption to a booking.

## Features

* User authentication
* User registration
* Booking creation
* Performing Check-in and check-out
* Adding an option to a booking
* Automatic JWT Bearer token management
* Dependency Injection support
* Strongly-typed request and response models

## Requirements

* .NET 10 or later
* Access to a running Artichaut API instance
