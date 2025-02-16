using Microsoft.Extensions.DependencyInjection;

namespace ConsoleConfigurationLibrary.Classes;

/// <summary>
/// Provides functionality to register and configure connection services for applications.
/// </summary>
public static class RegisterConnectionServices
{
    /// <summary>
    /// Configures the application by initializing required services and reading connection strings.
    /// </summary>
    /// <remarks>
    /// This method sets up the necessary service provider and retrieves connection strings
    /// from the application's configuration. It should be called at the start of the application
    /// to ensure all required services are properly initialized.
    /// </remarks>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public static async Task Configure()
    {
        var services = ApplicationConfiguration.ConfigureServices();
        await using var serviceProvider = services.BuildServiceProvider();
        serviceProvider.GetService<SetupServices>()!.GetConnectionStrings();
    }
}