using Microsoft.Extensions.Configuration;

namespace ConsoleConfigurationLibrary.Classes;

public class Configuration
{
    /// <summary>
    /// Setup to read appsettings.json
    /// </summary>
    public static IConfigurationRoot JsonRoot() =>
        new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false)
            .AddEnvironmentVariables()
            .Build();

    public static IConfigurationRoot JsonRootCommandLine(string[] args) =>
        new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false)
            .AddEnvironmentVariables()
            .AddCommandLine(args)
            .Build();

    /// <summary>
    /// Setup to read app.config
    /// </summary>
    public static IConfigurationRoot XmlRoot() =>
        new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddXmlFile("app.config", optional: true, reloadOnChange: true)
            .Build();

}