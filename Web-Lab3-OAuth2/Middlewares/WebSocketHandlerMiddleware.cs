using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using Web_Lab3_OAuth2.Models;
using Web_Lab3_OAuth2.Services;

namespace Web_Lab3_OAuth2.Middlewares;

public class WebSocketHandlerMiddleware : IMiddleware
{
    private readonly IConfiguration _config;
    private readonly ILogger<WebSocketHandlerMiddleware> _logger;
    private readonly Coins _coins;

    public WebSocketHandlerMiddleware(
        IConfiguration config,
        ILogger<WebSocketHandlerMiddleware> logger,
        Coins coins
    )
    {
        _config = config;
        _logger = logger;
        _coins = coins;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        _logger.LogInformation("Request URL: {0}://{1}{2}", context.Request.Scheme, context.Request.Host, context.Request.Path);

        if (context.Request.Path == "/ws" && context.WebSockets.IsWebSocketRequest)
        {
            using var clientWebSocket = await context.WebSockets.AcceptWebSocketAsync();
            using var binanceWebSocket = new ClientWebSocket();
            var cts = new CancellationTokenSource();

            try
            {
                var uri = new Uri($"{_config["Binance:HostUrl"]}{_config["Binance:StreamEndpoint"]}{_coins.CurrenciesTickerQuery}");
                await binanceWebSocket.ConnectAsync(uri, CancellationToken.None);

                var relayTask = Relay(clientWebSocket, binanceWebSocket, cts.Token);

                // Wait for the client to disconnect
                await WaitForClientDisconnection(clientWebSocket, cts);

                // Ensure the relay task completes
                await relayTask;
            }
            finally
            {
                if (binanceWebSocket.State == WebSocketState.Open)
                {
                    await binanceWebSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Binance WebSocket closed", CancellationToken.None);
                }

                if (clientWebSocket.State == WebSocketState.Open)
                {
                    await clientWebSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Client WebSocket closed", CancellationToken.None);
                }
            }
        }
        else
        {
            await next(context);
        }
    }

    private async Task Relay(WebSocket clientWebSocket, WebSocket binanceWebSocket, CancellationToken cancellationToken)
    {
        var buffer = new byte[1024 * 4];

        while (binanceWebSocket.State == WebSocketState.Open && !cancellationToken.IsCancellationRequested)
        {
            try
            {
                var result = await binanceWebSocket.ReceiveAsync(buffer, cancellationToken);

                if (result.MessageType == WebSocketMessageType.Close)
                {
                    await binanceWebSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Binance WebSocket closed", cancellationToken);
                    break;
                }

                var message = Encoding.UTF8.GetString(buffer, 0, result.Count);

                if (!string.IsNullOrEmpty(message))
                {
                    var response = JsonSerializer.Deserialize<BinanceResponse>(message);
                    _logger.LogInformation(
                        $"Received message from Binance:\n" +
                        $"\tstream: {response.Stream}\n" +
                        $"\tprice: {response.Data.LastPrice}"
                    );

                    var answer = JsonSerializer.Serialize(response);
                    var answerBytes = Encoding.UTF8.GetBytes(answer);

                    if (clientWebSocket.State == WebSocketState.Open)
                    {
                        await clientWebSocket.SendAsync(
                            new ArraySegment<byte>(answerBytes, 0, answerBytes.Length),
                            WebSocketMessageType.Text,
                            true,
                            cancellationToken
                        );
                    }
                }

            }
            catch (OperationCanceledException)
            {
                _logger.LogWarning("WebSocket operation was canceled.");
                break;
            }
            catch (WebSocketException ex)
            {
                _logger.LogWarning($"WebSocket error: {ex.Message}");
                break;
            }
        }
    }

    private async Task WaitForClientDisconnection(WebSocket clientWebSocket, CancellationTokenSource cts)
    {
        var buffer = new byte[1024 * 4];

        while (clientWebSocket.State == WebSocketState.Open)
        {
            try
            {
                var result = await clientWebSocket.ReceiveAsync(buffer, CancellationToken.None);

                if (result.MessageType == WebSocketMessageType.Close)
                {
                    cts.Cancel(); // Cancel the relay task
                    await clientWebSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Client disconnected", CancellationToken.None);
                    break;
                }

                var message = Encoding.UTF8.GetString(buffer, 0, result.Count);
                _logger.LogInformation($"Received message from client: {message}");
            }
            catch (WebSocketException ex)
            {
                _logger.LogWarning($"Client WebSocket error: {ex.Message}");
                cts.Cancel(); // Cancel the relay task
                break;
            }
        }
    }
}

public static class WebSocketHandlerMiddlewareExtensions
{
    public static IApplicationBuilder UseWebSocketHandlerMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<WebSocketHandlerMiddleware>();
    }
}
