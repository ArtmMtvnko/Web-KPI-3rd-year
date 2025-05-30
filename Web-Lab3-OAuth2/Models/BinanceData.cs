using System.Text.Json.Serialization;

namespace Web_Lab3_OAuth2.Models;

public class BinanceData
{
    [JsonPropertyName("s")]
    public string Symbol { get; set; }

    [JsonPropertyName("p")]
    public string PriceChange { get; set; }

    [JsonPropertyName("P")]
    public string PriceChangePercent { get; set; }

    [JsonPropertyName("c")]
    public string LastPrice { get; set; }

    // Rest of the data will be omitted automatically by JsonSerializer
}
