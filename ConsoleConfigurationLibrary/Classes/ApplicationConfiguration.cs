using ConsoleConfigurationLibrary.Models;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleConfigurationLibrary.Classes;
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