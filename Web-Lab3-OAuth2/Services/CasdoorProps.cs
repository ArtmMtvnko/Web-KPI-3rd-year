namespace Web_Lab3_OAuth2.Services;

public class CasdoorProps
{
    public string ConnectUrl { get; }

    public string LoginEndpoint { get; }

    public string TokenEndpoint { get; }

    public string CheckJwtEndpoint { get; }

    public string ClientId { get; }

    public string ClientSecret { get; }

    public string RedirectUrl { get; }

    public string ApplicationName { get; }

    public string OrganizationName { get; }


    public CasdoorProps(IConfiguration configuration)
    {
        ConnectUrl = configuration["Casdoor:ConnectUrl"] ?? string.Empty;
        LoginEndpoint = configuration["Casdoor:LoginEndpoint"] ?? string.Empty;
        TokenEndpoint = configuration["Casdoor:TokenEndpoint"] ?? string.Empty;
        CheckJwtEndpoint = configuration["Casdoor:CheckJwtEndpoint"] ?? string.Empty;
        ClientId = configuration["Casdoor:ClientId"] ?? string.Empty;
        ClientSecret = configuration["Casdoor:ClientSecret"] ?? string.Empty;
        RedirectUrl = configuration["Casdoor:RedirectUrl"] ?? string.Empty;
        ApplicationName = configuration["Casdoor:ApplicationName"] ?? string.Empty;
        OrganizationName = configuration["Casdoor:OrganizationName"] ?? string.Empty;
    }
}
