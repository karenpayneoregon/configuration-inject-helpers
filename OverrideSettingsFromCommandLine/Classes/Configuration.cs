using Microsoft.Extensions.Configuration;
using static ConsoleConfigurationLibrary.Classes.CommandLineOverride;
namespace OverrideSettingsFromCommandLine.Classes;
internal static class Configuration
{
    public static string ConnectionStrings(string[] args)
    {
        return BuilderRoot(args).GetConnectionString(
            nameof(ConsoleConfigurationLibrary.Models.ConnectionStrings.MainConnection));
    }
}
