using ConsoleConfigurationLibrary.Models;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleConfigurationLibrary.Classes;
/// <summary>
/// Provides configuration methods for setting up application services, including dependency injection
/// and configuration bindings for connection strings and entity settings.
/// </summary>
/// <remarks>
/// This class is responsible for initializing and configuring the application's services, ensuring
/// that all necessary dependencies and configurations are properly set up before the application starts.
/// </remarks>
public class ApplicationConfiguration
{
  
    /// <summary>
    /// Start-up code which needs to run first before reading any connection strings from appsettings.json
    /// </summary>
    public static ServiceCollection ConfigureServices()
    {
        static void ConfigureService(IServiceCollection services)
        {
            services.Configure<ConnectionStrings>(Configuration.JsonRoot().GetSection(nameof(ConnectionStrings)));
            services.Configure<EntityConfiguration>(Configuration.JsonRoot().GetSection(nameof(EntityConfiguration)));
            services.AddTransient<SetupServices>();
        }

        var services = new ServiceCollection();
        ConfigureService(services);

        return services;

    }
}