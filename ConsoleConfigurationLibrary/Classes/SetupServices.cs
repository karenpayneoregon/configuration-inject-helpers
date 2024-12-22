using ConsoleConfigurationLibrary.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;


namespace ConsoleConfigurationLibrary.Classes;
public class SetupServices
{
    private readonly ConnectionStrings _options;
    private readonly EntityConfiguration _settings;

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

    public static async Task Setup()
    {
        var services = ApplicationConfiguration.ConfigureServices();
        await using var serviceProvider = services.BuildServiceProvider();
        serviceProvider.GetService<SetupServices>()!.GetConnectionStrings();
        serviceProvider.GetService<SetupServices>()!.GetEntitySettings();
    }
}