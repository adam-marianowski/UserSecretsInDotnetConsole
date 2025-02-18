using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = Host.CreateDefaultBuilder(args).ConfigureAppConfiguration((hostContext, config) => {
    config
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddUserSecrets<Program>(optional: true, reloadOnChange: true);
}).Build();

var configuration = host.Services.GetRequiredService<IConfiguration>();
var value = configuration["Secret"];

Console.WriteLine($"Secret: {value}");