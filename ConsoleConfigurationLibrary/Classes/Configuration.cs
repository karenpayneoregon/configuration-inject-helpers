using Microsoft.Extensions.Configuration;
using System.Reflection;
using System;

namespace ConsoleConfigurationLibrary.Classes;

public class Configuration
{

    /// <summary>
    /// Builds and returns an <see cref="IConfigurationRoot"/> object configured to read settings from a JSON file.
    /// </summary>
    /// <returns>An <see cref="IConfigurationRoot"/> object that reads configuration settings from "appsettings.json" and environment variables.</returns>
    public static IConfigurationRoot JsonRoot() =>
        new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false)
            .AddEnvironmentVariables()
            .Build();

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

    /// <summary>
    /// Builds and returns an <see cref="IConfigurationRoot"/> object configured to read settings from a JSON file,
    /// environment variables, and command-line arguments.
    /// </summary>
    /// <param name="args">An array of command-line arguments to be included in the configuration.</param>
    /// <returns>An <see cref="IConfigurationRoot"/> object that reads configuration settings from "appsettings.json",
    /// environment variables, and command-line arguments.</returns>
    public static IConfigurationRoot JsonRootCommandLine(string[] args) =>
        new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false)
            .AddEnvironmentVariables()
            .AddCommandLine(args)
            .Build();


    /// <summary>
    /// Builds and returns an <see cref="IConfigurationRoot"/> object configured to read settings from an XML file.
    /// </summary>
    /// <returns>An <see cref="IConfigurationRoot"/> object that reads configuration settings from "app.config" and environment variables.</returns>
    public static IConfigurationRoot XmlRoot() =>
        new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddXmlFile("app.config", optional: true, reloadOnChange: true)
            .Build();

}