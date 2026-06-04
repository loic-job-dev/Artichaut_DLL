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

This allows to display the error messages sent by the API in case of 409 status code by exemple

## Features

* User authentication
* User registration
* Booking creation
* Automatic JWT Bearer token management
* Dependency Injection support
* Strongly-typed request and response models

## Requirements

* .NET 10 or later
* Access to a running Artichaut API instance
