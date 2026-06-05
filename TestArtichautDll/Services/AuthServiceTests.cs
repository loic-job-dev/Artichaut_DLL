using ArtichautLibrary.Providers;
using ArtichautLibrary.Services;
using TestArtichautDll.Helpers;

namespace TestArtichautDll.Services;

[TestFixture]
public class AuthServiceTests
{
    private HttpClient _httpClient = null!;
    private FakeHttpAuthMessageHandler _authHandler = null!;
    private AuthService _authService = null!;
    private TokenProvider _tokenProvider = null!;

    [SetUp]
    public void Setup()
    {
        _authHandler = new FakeHttpAuthMessageHandler();
        _tokenProvider = new TokenProvider();

        _httpClient = new HttpClient(_authHandler)
        {
            BaseAddress = new Uri("http://localhost:8080")
        };

        _authService = new AuthService(_httpClient, _tokenProvider);
    }
    
    [TearDown]
    public void TearDown()
    {
        _httpClient.Dispose();
        _authHandler.Dispose();
    }

    [Test]
    public async Task Login_Should_Return_AuthResponse_And_Store_Token()
    {
        var result = await _authService.Login("test@test.com", "password");

        Assert.That(result.Success, Is.True);
        Assert.That(result.Data, Is.Not.Null);
        Assert.That(result.Data!.AccessToken, Is.EqualTo("fake-jwt-token"));

        Assert.That(_tokenProvider.GetToken(), Is.EqualTo("fake-jwt-token"));
    }

    [Test]
    public async Task Login_Should_Send_Post_Request()
    {
        await _authService.Login(
            "test@test.com",
            "password");

        Assert.That(
            _authHandler.LastRequest!.Method,
            Is.EqualTo(HttpMethod.Post));
    }

    [Test]
    public async Task Login_Should_Call_Auth_Login_Endpoint()
    {
        await _authService.Login(
            "test@test.com",
            "password");

        Assert.That(
            _authHandler.LastRequest!.RequestUri!.AbsolutePath,
            Is.EqualTo("/auth/login"));
    }
    

    [Test]
    public async Task Logout_Should_Delete_Bearer_Token()
    {
        await _authService.Login(
            "test@test.com",
            "password");
        
        Assert.That(_tokenProvider.GetToken(), Is.EqualTo("fake-jwt-token"));
        
        _authService.Logout();
        
        Assert.That(_tokenProvider.GetToken(), Is.Null);
    }
}