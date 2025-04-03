using System.Net;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.WebHost.ConfigureKestrel(options =>
{
    var certPath = builder.Configuration["CertPath"];
    var certPass = builder.Configuration["Passwords:CertPass"];
    var host = Dns.GetHostEntry("localhost").AddressList.First();

    options.Listen(host, 5000);
    options.Listen(host, 5001, listOptions =>
    {
        listOptions.UseHttps(certPath, certPass);
    });
});

var app = builder.Build();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
