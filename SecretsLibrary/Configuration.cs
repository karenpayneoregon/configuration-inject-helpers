using System.Reflection;
using Microsoft.Extensions.Configuration;

namespace SecretsLibrary;
public class Configuration
{
    /// <summary>
    /// Builds and returns an <see cref="IConfigurationRoot"/> object configured to read settings from JSON files,
    /// user secrets, and environment variables.
    /// </summary>
    /// <returns>An <see cref="IConfigurationRoot"/> object that reads configuration settings from "appsettings.json",
    /// "appsettings.{environment}.json", user secrets, and environment variables.</returns>
    public static IConfigurationRoot JsonRootSecrets()
    {
        var environment = Environment.GetEnvironmentVariable("NETCORE_ENVIRONMENT");
        return new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .AddJsonFile($"appsettings.{environment}.json", optional: true)
            .AddUserSecrets(Assembly.GetExecutingAssembly(), true)
            .AddEnvironmentVariables()
            .Build();
    }
}
