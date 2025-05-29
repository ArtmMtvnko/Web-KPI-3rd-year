using System.Text.Json.Serialization;

namespace Web_Lab3_OAuth2.Models;

public class BinanceResponse
{
    [JsonPropertyName("stream")]
    public string Stream { get; set; }

    [JsonPropertyName("data")]
    public BinanceData Data { get; set; }
}
