using System.Net;
using System.Text;

namespace TestArtichautDll.Helpers;

public class FakeHttpBookingMessageHandler : HttpMessageHandler
{
    public HttpRequestMessage? LastRequest { get; private set; }

    public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.OK;

    public string ResponseContent { get; set; } = """
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

    protected override Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        LastRequest = request;

        return Task.FromResult(
            new HttpResponseMessage(StatusCode)
            {
                Content = new StringContent(
                    ResponseContent,
                    Encoding.UTF8,
                    "application/json")
            });
    }
}