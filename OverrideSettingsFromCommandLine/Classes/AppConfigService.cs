using static ConsoleConfigurationLibrary.Classes.AppConnections;

namespace OverrideSettingsFromCommandLine.Classes;
internal static class AppConfigService
{
    public static string ConnectionStrings()
    {
        return Instance.MainConnection;
    }
}
