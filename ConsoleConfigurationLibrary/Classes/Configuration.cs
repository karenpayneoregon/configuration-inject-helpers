using Microsoft.Extensions.Configuration;

namespace ConsoleConfigurationLibrary.Classes;

public class Configuration
{
    public static IConfigurationRoot Root() =>
        new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false)
            .AddEnvironmentVariables()
            .Build();

}