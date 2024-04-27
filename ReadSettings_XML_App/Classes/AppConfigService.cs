using ConsoleConfigurationLibrary.Classes;
using Microsoft.Extensions.Configuration;
using ReadSettings_XML_App.Models;

namespace ReadSettings_XML_App.Classes;
public static class AppConfigService
{
    public static ConnectionStringOptions ConnectionStrings() =>
        Configuration.XmlRoot()
            .GetSection(ConnectionStringOptions.Position)
            .Get<ConnectionStringOptions>();

    public static PositionOptions GeneralSettings() =>
        Configuration.XmlRoot()
            .GetSection(PositionOptions.Position)
            .Get<PositionOptions>();

    public static string ApplicationKey() 
        => Configuration.XmlRoot()["AppKey"];

    public static Logging ApplicationLogging()
        => Configuration.XmlRoot().GetSection(Logging.Position).Get<Logging>();
}
