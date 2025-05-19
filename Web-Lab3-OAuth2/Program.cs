using System.Net;
using Web_Lab3_OAuth2.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.WebHost.ConfigureKestrel(options =>
{
    var certPath = builder.Configuration["CertPath"];
    var certPass = builder.Configuration["CertPass"];
    var host = Dns.GetHostEntry("localhost").AddressList.First();

    options.Listen(host, 5222);
    options.Listen(host, 5443, listOptions =>
    {
        listOptions.UseHttps(certPath, certPass);
    });
});

builder.Services.AddControllers();

builder.Services.AddHttpClient();

builder.Services.AddSingleton<CasdoorProps>();

builder.Services.AddSingleton<JwtDecoder>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseStaticFiles();
app.MapFallbackToFile("index.html");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
