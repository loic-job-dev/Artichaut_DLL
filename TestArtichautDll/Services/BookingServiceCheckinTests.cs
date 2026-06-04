using System.Net;
using ArtichautLibrary.Services;
using TestArtichautDll.Helpers;

namespace TestArtichautDll.Services;

[TestFixture]
public class BookingServiceCheckinTests
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
    public async Task Checkin_Should_Return_BookingResponse()
    {
        var result = await _bookingService.Checkin(
            "BOOKED",
            new DateOnly(2026, 6, 3),
            "55a35480-649b-4869-a028-88a9db9d18e9",
            "b5444c27-8359-438e-87d3-cc0fde60a4d5");

        Assert.That(result.Success, Is.True);
        Assert.That(result.Data, Is.Not.Null);
        Assert.That(
            result.Data!.RoomUnitPrice,
            Is.EqualTo(280));
    }

    [Test]
    public async Task Checkin_Should_Send_Put_Request()
    {
        await _bookingService.Checkin(
            "BOOKED",
            new DateOnly(2026, 6, 3),
            "55a35480-649b-4869-a028-88a9db9d18e9",
            "b5444c27-8359-438e-87d3-cc0fde60a4d5");

        Assert.That(
            _handler.LastRequest!.Method,
            Is.EqualTo(HttpMethod.Put));
    }

    [Test]
    public async Task Checkin_Should_Call_Checkin_Endpoint()
    {
        const string bookingId = "b5444c27-8359-438e-87d3-cc0fde60a4d5";

        await _bookingService.Checkin(
            "BOOKED",
            new DateOnly(2026, 6, 3),
            "55a35480-649b-4869-a028-88a9db9d18e9",
            bookingId);

        Assert.That(
            _handler.LastRequest!.RequestUri!.AbsolutePath,
            Is.EqualTo($"/bookings/{bookingId}/checkin"));
    }

    [Test]
    public async Task Checkin_Should_Return_Error_When_Conflict()
    {
        _handler.StatusCode = HttpStatusCode.Conflict;
        _handler.ResponseContent = "Room already checked in";

        var result = await _bookingService.Checkin(
            "BOOKED",
            new DateOnly(2026, 6, 3),
            "55a35480-649b-4869-a028-88a9db9d18e9",
            "b5444c27-8359-438e-87d3-cc0fde60a4d5");

        Assert.That(result.Success, Is.False);
        Assert.That(result.Data, Is.Null);
        Assert.That(
            result.ErrorMessage,
            Is.EqualTo("Room already checked in"));
    }

    [Test]
    public async Task Checkin_Should_Return_Connection_Error_For_Unexpected_Status()
    {
        _handler.StatusCode = HttpStatusCode.InternalServerError;

        var result = await _bookingService.Checkin(
            "BOOKED",
            new DateOnly(2026, 6, 3),
            "55a35480-649b-4869-a028-88a9db9d18e9",
            "b5444c27-8359-438e-87d3-cc0fde60a4d5");

        Assert.That(result.Success, Is.False);
        Assert.That(result.Data, Is.Null);
        Assert.That(
            result.ErrorMessage,
            Is.EqualTo("Erreur de connexion à l'API"));
    }
}