using System.Net;
using System.Text;

namespace TestArtichautDll.Helpers;

public class FakeHttpAuthMessageHandler : HttpMessageHandler
{
    public HttpRequestMessage? LastRequest { get; private set; }

    protected override Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        LastRequest = request;

        var json = """
                   {
                       "accessToken":"fake-jwt-token",
                       "userId":"16919cfb-49fe-11f1-834b-cc641aee987d"
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