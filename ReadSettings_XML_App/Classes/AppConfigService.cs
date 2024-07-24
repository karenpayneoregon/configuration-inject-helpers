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
        => Configuration.XmlRoot().GetSection(Logging.Position)
            .Get<Logging>();

    /// <summary>
    /// Original code from Microsoft
    /// https://learn.microsoft.com/en-us/dotnet/core/extensions/configuration-providers#xml-configuration-provider
    /// </summary>
    /// <returns></returns>
    public static (Section section1, Section section2, Section section3, Section section4) Sections()
    {
        var configurationRoot = Configuration.XmlRoot();

        var key00 = "section:section0:key:key0";
        var key01 = "section:section0:key:key1";
        var key10 = "section:section1:key:key0";
        var key11 = "section:section1:key:key1";

        int val00 = Convert.ToInt32(configurationRoot[key00]);
        int val01 = Convert.ToInt32(configurationRoot[key01]);
        int val10 = Convert.ToInt32(configurationRoot[key10]);
        int val11 = Convert.ToInt32(configurationRoot[key11]);

        return (
            new Section { Key = key00.Replace("section:section0:key:", ""), Value = val00 },
            new Section { Key = key01.Replace("section:section0:key:", ""), Value = val01 },
            new Section { Key = key10.Replace("section:section1:key:", ""), Value = val10 },
            new Section { Key = key10.Replace("section:section1:key:", ""), Value = val11 }
            );
    }
}