using System.Net;
using System.Text;

namespace TestArtichautDll.Helpers;

public class FakeHttpBookingMessageHandler : HttpMessageHandler
{
    public HttpRequestMessage? LastRequest { get; private set; }

    protected override Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        LastRequest = request;

        var json = """
                   {
                     "id": "55a35480-649b-4869-a028-88a9db9d18e9",
                     "validationDate": "2026-06-03",
                     "startBookedDate": "2026-06-03",
                     "endBookedDate": "2026-06-05",
                     "adultNumber": 2,
                     "childrenNumber": 0,
                     "roomUnitPrice": 280,
                     "status": "BOOKED"
                   }
                   """;

        return Task.FromResult(
            new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(
                    json,
                    Encoding.UTF8,
                    "application/json")
            });
    }
}