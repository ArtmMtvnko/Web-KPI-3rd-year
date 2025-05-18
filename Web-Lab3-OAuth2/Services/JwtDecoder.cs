using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using Web_Lab3_OAuth2.Models;

namespace Web_Lab3_OAuth2.Services;

public class JwtDecoder
{
    private readonly HttpClient _httpClient;
    private readonly CasdoorProps _casdoorProps;
    private readonly ILogger<JwtDecoder> _logger;

    public JwtDecoder(HttpClient httpClient, CasdoorProps casdoorProps, ILogger<JwtDecoder> logger)
    {
        _httpClient = httpClient;
        _casdoorProps = casdoorProps;
        _logger = logger;
    }

    public async Task<UserPayload> DecodeJwt(string jwtToken)
    {
        var response = await _httpClient.GetStringAsync($"{_casdoorProps.ConnectUrl}{_casdoorProps.CheckJwtEndpoint}");
        var jwks = JObject.Parse(response)["keys"] as JArray;

        var validationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            RequireExpirationTime = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            IssuerSigningKeyResolver = (token, securityToken, kid, parameters) =>
            {
                var key = jwks.FirstOrDefault(x => x["kid"].ToString() == kid);

                if (key == null)
                    throw new SecurityTokenException($"Key with kid = {kid} is not found");

                var n = Base64UrlEncoder.DecodeBytes(key["n"].ToString());
                var e = Base64UrlEncoder.DecodeBytes(key["e"].ToString());

                var rsaParams = new RSAParameters { Modulus = n, Exponent = e };
                var rsa = RSA.Create();
                rsa.ImportParameters(rsaParams);

                return new[] { new RsaSecurityKey(rsa) { KeyId = kid } };
            }
        };

        var tokenHandler = new JwtSecurityTokenHandler();

        try
        {
            SecurityToken validatedToken;
            var principal = tokenHandler.ValidateToken(jwtToken, validationParameters, out validatedToken);

            var jwtTokenObj = validatedToken as JwtSecurityToken;
            
            var payload = jwtTokenObj.Payload;

            _logger.LogInformation($"TOKEN: {jwtTokenObj.Payload.SerializeToJson()}");

            return new UserPayload
            {
                Id = payload["id"].ToString(),
                Name = payload["name"].ToString(),
                DisplayName = payload["displayName"].ToString(),
                Type = payload["type"].ToString(),
                Owner = payload["owner"].ToString()
            };
        }
        catch (SecurityTokenExpiredException)
        {
            _logger.LogError("Token expired");
            throw;
        }
        catch (SecurityTokenException)
        {
            _logger.LogError("Invalid token");
            throw;
        }
    } 
}
