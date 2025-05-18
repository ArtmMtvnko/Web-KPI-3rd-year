using Microsoft.AspNetCore.Mvc;
using Web_Lab3_OAuth2.Services;

namespace Web_Lab3_OAuth2.Controllers;

[Route("[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly JwtDecoder _jwtDecoder;

    public UserController(JwtDecoder jwtDecoder)
    {
        _jwtDecoder = jwtDecoder;
    }

    [HttpGet("info")]
    public async Task<IActionResult> UserInfo()
    {
        var access_token = Request.Cookies["access_token"];

        var userPayload = await _jwtDecoder.DecodeJwt(access_token);

        return Ok(userPayload);
    }
}
