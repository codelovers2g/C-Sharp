using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using InventorySystem.Application.Interfaces;
using InventorySystem.Application.Services;
using InventorySystem.App;

// Configures the application host, enabling Dependency Injection and standardized lifecycle management.
using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((_, services) =>
    {
        services.AddSingleton<IInventoryService, InventoryService>();
        services.AddSingleton<IConsoleInterface, ConsoleInterface>();
        services.AddTransient<App>();
    })
    .Build();

// Entry point resolution: Ensures all dependencies are injected before starting the execution loop.
App app = host.Services.GetRequiredService<App>();
app.Run();
