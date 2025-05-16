using System.Net.Mime;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web_Lab3_OAuth2.Models;
using Web_Lab3_OAuth2.Services;

namespace Web_Lab3_OAuth2.Controllers;

[Route("[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly ILogger<AuthController> _logger;
    private readonly CasdoorProps _casdoorProps;
    private readonly HttpClient _httpClient;

    public AuthController(
        ILogger<AuthController> logger,
        CasdoorProps casdoorProps,
        HttpClient httpClient
    )
    {
        _logger = logger;
        _casdoorProps = casdoorProps;
        _httpClient = httpClient;
    }

    [HttpGet("login")]
    public IActionResult Login()
    {
        var authUrl = $"{_casdoorProps.ConnectUrl}" +
            $"{_casdoorProps.LoginEndpoint}" +
            $"?client_id={_casdoorProps.ClientId}" +
            $"&redirect_uri={_casdoorProps.RedirectUrl}" +
            $"&response_type=code" +
            $"&scope=openid profile email";

        _logger.LogInformation($"Authorize URL: {authUrl}");

        return Redirect(authUrl);
    }

    [HttpGet("callback")]
    public async Task<IActionResult> CallbackAsync([FromQuery] string code)
    {
        _logger.LogInformation($"Received code: {code}");

        var tokenUrl = $"{_casdoorProps.ConnectUrl}" +
            $"{_casdoorProps.TokenEndpoint}" +
            $"?client_id={_casdoorProps.ClientId}" +
            $"&client_secret={_casdoorProps.ClientSecret}" +
            $"&code={code}" +
            $"&grant_type=authorization_code";

        _logger.LogInformation($"Token URL: {tokenUrl}");

        var tokenResponse = await _httpClient.PostAsync(tokenUrl, null);

        if (!tokenResponse.IsSuccessStatusCode)
        {
            _logger.LogError($"Failed to get token: {await tokenResponse.Content.ReadAsStringAsync()}");
            return StatusCode((int)tokenResponse.StatusCode, "Failed to get token");
        }

        _logger.LogInformation($"Token response: {await tokenResponse.Content.ReadAsStringAsync()}");

        var tokenResponseContent = await tokenResponse.Content.ReadFromJsonAsync<TokenResponse>();

        if (tokenResponseContent == null)
        {
            _logger.LogError("Token response content is null");
            return StatusCode(StatusCodes.Status500InternalServerError, "Token response content is null");
        }

        var accessToken = tokenResponseContent.AccessToken;

        var cookieOptions = new CookieOptions()
        {
            HttpOnly = true,
            Secure = true,
            SameSite = SameSiteMode.Strict,
            Expires = DateTimeOffset.UtcNow.AddHours(6)
        };

        Response.Cookies.Append("access_token", accessToken, cookieOptions);

        return Redirect("/");
    }
}
