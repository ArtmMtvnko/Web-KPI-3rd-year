using Google.Protobuf;
using Microsoft.AspNetCore.Mvc;

namespace Web_Lab3_OAuth2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("protobuf")]
        public byte[] GetProtobuf()
        {
            var json = @"
            {
                ""stream"": ""btcusdt@ticker"",
                ""data"": {
                    ""symbol"": ""BTCUSDT"",
                    ""priceChange"": ""-0.01000000"",
                    ""priceChangePercent"": ""-0.010"",
                    ""lastPrice"": ""101.4665""
                }
            }
            ";

            var parser = new JsonParser(JsonParser.Settings.Default);
            var message = parser.Parse<BinanceResponseProtobuf>(json);

            return message.ToByteArray();
        }
    }
}
