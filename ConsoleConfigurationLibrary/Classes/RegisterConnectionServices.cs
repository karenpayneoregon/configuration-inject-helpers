using Microsoft.Extensions.DependencyInjection;

namespace ConsoleConfigurationLibrary.Classes;

public static class RegisterConnectionServices
{
    public static async Task Configure()
    {
        var services = ApplicationConfiguration.ConfigureServices();
        await using var serviceProvider = services.BuildServiceProvider();
        serviceProvider.GetService<SetupServices>()!.GetConnectionStrings();
    }
}