// See https://aka.ms/new-console-template for more information
using CommandLine;
using MediatR;
using Microsoft.Extensions.Hosting;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

var builder = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        services.AddLogging(configure => configure.AddConsole().SetMinimumLevel(LogLevel.Warning));
        services.AddTransient<App>();
        services.AddMediatR(typeof(Program));
    });

var host = builder.Build();

using var serviceScope = host.Services.CreateScope();
{
    var services = serviceScope.ServiceProvider;

    try
    {
        var myService = services.GetRequiredService<App>();
        await myService.Run(args);

    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error Occurred {ex}");
    }
}

class App(IMediator mediator)
{
    public Task Run(string[] args)
    {
        var types = Assembly.GetExecutingAssembly().GetTypes()
            .Where(t => t.GetCustomAttribute<VerbAttribute>() != null).ToArray();

        return Parser.Default.ParseArguments(args, types)
            .WithParsedAsync(o => mediator.Send(o));
    }
}
