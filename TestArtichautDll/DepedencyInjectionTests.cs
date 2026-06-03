using ArtichautLibrary;
using Microsoft.Extensions.DependencyInjection;

namespace TestArtichautDll;

[TestFixture]
public class DependencyInjectionTests
{
    [Test]
    public void AddArtichautClient_Should_Register_Client()
    {
        var services = new ServiceCollection();

        services.AddArtichautClient(
            "http://localhost:8080");

        var provider = services.BuildServiceProvider();

        var client =
            provider.GetRequiredService<ArtichautClient>();

        Assert.That(client, Is.Not.Null);
    }
}