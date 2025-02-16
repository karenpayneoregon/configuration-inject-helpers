using Microsoft.Extensions.Configuration;

namespace ConsoleConfigurationLibrary.Classes;
/// <summary>
/// Provides functionality to override configuration settings using command line arguments.
/// </summary>
public class CommandLineOverride
{
    /// <summary>
    /// Builds the configuration root based on the command line arguments.
    /// </summary>
    /// <param name="args">The command line arguments.</param>
    /// <returns>The configuration root.</returns>
    public static IConfigurationRoot BuilderRoot(string[] args)
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables();

        if (args is not null)
            builder.AddCommandLine(args);

        return builder.Build();
    }
}
