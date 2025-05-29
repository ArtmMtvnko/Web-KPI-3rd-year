namespace Web_Lab3_OAuth2.Services;

public class Coins
{
    private readonly List<string> _currencies =
    [
        "btc", "eth", "doge", "xrp"
    ];

    private readonly string _currencyToCompare = "usdt";

    public string CurrenciesTickerQuery
    {
        get
        {
            return string.Join('/', _currencies.Select(x => $"{x}{_currencyToCompare}@ticker"));
        }
    }
}
