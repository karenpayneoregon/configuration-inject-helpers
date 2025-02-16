using ConsoleConfigurationLibrary.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;


namespace ConsoleConfigurationLibrary.Classes;
/// <summary>
/// Provides methods to configure and retrieve application settings, such as connection strings and entity configurations, 
/// from the application's configuration files.
/// </summary>
public class SetupServices
{
    private readonly ConnectionStrings _options;
    private readonly EntityConfiguration _settings;

    /// <summary>
    /// Initializes a new instance of the <see cref="SetupServices"/> class.
    /// </summary>
    /// <param name="options">
    /// An instance of <see cref="IOptions{TOptions}"/> containing the application's connection strings.
    /// </param>
    /// <param name="settings">
    /// An instance of <see cref="IOptions{TOptions}"/> containing the application's entity configuration settings.
    /// </param>
    public SetupServices(IOptions<ConnectionStrings> options, IOptions<EntityConfiguration> settings)
    {
        _options = options.Value;
        _settings = settings.Value;
    }
    /// <summary>
    /// Read connection strings from appsettings
    /// </summary>
    public void GetConnectionStrings()
    {
        AppConnections.Instance.MainConnection = _options.MainConnection;
        AppConnections.Instance.SecondaryConnection = _options.SecondaryConnection;
        AppConnections.Instance.OtherConnection = _options.OtherConnection;
    }

    /// <summary>
    /// Gets the entity settings from configuration.
    /// </summary>
    public void GetEntitySettings()
    {
        EntitySettings.Instance.CreateNew = _settings.CreateNew;
    }

    /// <summary>
    /// Configures and initializes application services, including connection strings and entity settings, 
    /// by reading from the application's configuration files.
    /// </summary>
    /// <remarks>
    /// This method sets up the dependency injection container, retrieves the required services, 
    /// and initializes the application's connection strings and entity settings.
    /// </remarks>
    /// <returns>
    /// A <see cref="Task"/> that represents the asynchronous operation of setting up the services.
    /// </returns>
    public static async Task Setup()
    {
        var services = ApplicationConfiguration.ConfigureServices();
        await using var serviceProvider = services.BuildServiceProvider();
        serviceProvider.GetService<SetupServices>()!.GetConnectionStrings();
        serviceProvider.GetService<SetupServices>()!.GetEntitySettings();
    }
}