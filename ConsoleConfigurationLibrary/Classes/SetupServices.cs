using ConsoleConfigurationLibrary.Models;
using Microsoft.Extensions.Options;

namespace ConsoleConfigurationLibrary.Classes;
public class SetupServices
{
    private readonly ConnectionStrings _options;

    public SetupServices(IOptions<ConnectionStrings> options)
    {
        _options = options.Value;
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

    //private static async Task Setup()
    //{
    //    var services = ApplicationConfiguration.ConfigureServices();
    //    await using var serviceProvider = services.BuildServiceProvider();
    //    serviceProvider.GetService<SetupServices>()!.GetConnectionStrings();
    //}
}