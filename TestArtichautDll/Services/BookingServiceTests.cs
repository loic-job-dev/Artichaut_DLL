using System.Net;
using ArtichautLibrary.Services;
using TestArtichautDll.Helpers;

namespace TestArtichautDll.Services;

[TestFixture]
public class BookingServiceTests
{
    private HttpClient _httpClient = null!;
    private FakeHttpBookingMessageHandler _handler = null!;
    private BookingService _bookingService = null!;

    [SetUp]
    public void Setup()
    {
        _handler = new FakeHttpBookingMessageHandler();

        _httpClient = new HttpClient(_handler)
        {
            BaseAddress = new Uri("http://localhost:8080")
        };

        _bookingService = new BookingService(_httpClient);
    }

    [TearDown]
    public void TearDown()
    {
        _httpClient.Dispose();
        _handler.Dispose();
    }

    [Test]
    public async Task CreateBooking_Should_Return_BookingResponse()
    {
        var result = await _bookingService.CreateBooking(
            new DateOnly(2026, 6, 3),
            new DateOnly(2026, 6, 5),
            2,
            0,
            "STE");

        Assert.That(result.Success, Is.True);
        Assert.That(result.Data, Is.Not.Null);
        Assert.That(
            result.Data!.RoomUnitPrice,
            Is.EqualTo(280));
    }

    [Test]
    public async Task CreateBooking_Should_Send_Post_Request()
    {
        await _bookingService.CreateBooking(
            new DateOnly(2026, 6, 3),
            new DateOnly(2026, 6, 5),
            2,
            0,
            "STE");

        Assert.That(
            _handler.LastRequest!.Method,
            Is.EqualTo(HttpMethod.Post));
    }

    [Test]
    public async Task CreateBooking_Should_Call_Bookings_Endpoint()
    {
        await _bookingService.CreateBooking(
            new DateOnly(2026, 6, 3),
            new DateOnly(2026, 6, 5),
            2,
            0,
            "STE");

        Assert.That(
            _handler.LastRequest!.RequestUri!.AbsolutePath,
            Is.EqualTo("/bookings"));
    }

    [Test]
    public async Task CreateBooking_Should_Return_Correct_Status()
    {
        var result = await _bookingService.CreateBooking(
            new DateOnly(2026, 6, 3),
            new DateOnly(2026, 6, 5),
            2,
            0,
            "STE");

        Assert.That(
            result.Data!.Status,
            Is.EqualTo("BOOKED"));
    }
    
    [Test]
    public async Task CreateBooking_Should_Return_Error_When_Conflict()
    {
        _handler.StatusCode = HttpStatusCode.Conflict;
        _handler.ResponseContent = "Room already booked";

        var result = await _bookingService.CreateBooking(
            new DateOnly(2026, 6, 3),
            new DateOnly(2026, 6, 5),
            2,
            0,
            "STE");

        Assert.That(result.Success, Is.False);
        Assert.That(result.Data, Is.Null);
        Assert.That(
            result.ErrorMessage,
            Is.EqualTo("Room already booked"));
    }
}