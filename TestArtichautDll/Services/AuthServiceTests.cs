using ArtichautLibrary.Services;
using TestArtichautDll.Helpers;

namespace TestArtichautDll.Services;

[TestFixture]
public class AuthServiceTests
{
    private HttpClient _httpClient = null!;
    private FakeHttpAuthMessageHandler _authHandler = null!;
    private AuthService _authService = null!;

    [SetUp]
    public void Setup()
    {
        _authHandler = new FakeHttpAuthMessageHandler();

        _httpClient = new HttpClient(_authHandler)
        {
            BaseAddress = new Uri("http://localhost:8080")
        };

        _authService = new AuthService(_httpClient);
    }
    
    [TearDown]
    public void TearDown()
    {
        _httpClient.Dispose();
        _authHandler.Dispose();
    }

    [Test]
    public async Task Login_Should_Return_AuthResponse()
    {
        var result = await _authService.Login(
            "test@test.com",
            "password");

        Assert.That(result.Success, Is.True);
        Assert.That(result.Data, Is.Not.Null);
        Assert.That(result.Data.AccessToken, Is.EqualTo("fake-jwt-token"));
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
    public async Task Login_Should_Set_Bearer_Token()
    {
        await _authService.Login(
            "test@test.com",
            "password");

        Assert.That(
            _httpClient.DefaultRequestHeaders.Authorization,
            Is.Not.Null);

        Assert.That(
            _httpClient.DefaultRequestHeaders.Authorization!.Scheme,
            Is.EqualTo("Bearer"));

        Assert.That(
            _httpClient.DefaultRequestHeaders.Authorization.Parameter,
            Is.EqualTo("fake-jwt-token"));
    }

    [Test]
    public async Task Login_Should_Store_AccessToken()
    {
        await _authService.Login(
            "test@test.com",
            "password");

        Assert.That(
            _authService.AccessToken,
            Is.EqualTo("fake-jwt-token"));
    }

    [Test]
    public async Task Logout_Should_Delete_Bearer_Token()
    {
        await _authService.Login(
            "test@test.com",
            "password");
        
        Assert.That(
            _authService.AccessToken,
            Is.EqualTo("fake-jwt-token"));
        
        _authService.Logout();
        
        Assert.That(
            _httpClient.DefaultRequestHeaders.Authorization, 
            Is.Null);
        Assert.That(
            _authService.AccessToken,
            Is.Null);
    }
}