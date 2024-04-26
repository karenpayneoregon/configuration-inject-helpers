using ConsoleConfigurationLibrary.Classes;
using Microsoft.Extensions.Configuration;
using static ReadSettingsApp.Classes.SpectreConsoleHelpers;

namespace ReadSettingsApp;

internal partial class Program
{
    static void Main(string[] args)
    {
        var _configuration = ApplicationConfiguration.ConfigurationRoot();

        var serverUrl = _configuration.GetValue<string>("Serilog:WriteTo:0:Args:serverUrl");
        AnsiConsole.MarkupLine($"[yellow]Serilog/WriteTo/Args.serverUrl[/] [cyan]{serverUrl}[/]");

        LineSeparator();

        AnsiConsole.MarkupLine("[yellow]ServiceDetails[/]");
        var details = _configuration.GetSection("ServiceDetails:CellDetails").GetChildren();

        foreach (var item in details)
        {
            Console.WriteLine($"{item.Key, -15}{item.GetSection("0").Value}, {item.GetSection("1").Value}");
        }

        LineSeparator();

        var appSettings = _configuration.GetRequiredSection("Settings").Get<AppSettings>();
        AnsiConsole.MarkupLine("[yellow]ServiceDetails[/]");
        Console.WriteLine($"   UseMemory: {appSettings.UseMemory}");
        Console.WriteLine($"Cors.Origins: {appSettings.Cors.Origins}");
        Console.WriteLine($"Cors.Headers: {appSettings.Cors.Headers}");
        Console.WriteLine($"Cors.Methods: {appSettings.Cors.Methods}");

        LineSeparator();

        AnsiConsole.MarkupLine("[yellow]Mail addresses[/]");
        List<MailAddress> addresses =
            _configuration.GetSection($"{nameof(Settings1)}:{nameof(MailAddress)}")
                .Get<MailAddress[]>().ToList();
        foreach (var address in addresses)
        {
            Console.WriteLine($"{address.Display,-14}{address.Address}");
        }


        ExitPrompt();
    }
}

public class AppSettings
{
    public bool? UseMemory { get; set; }
    public CorsSettings? Cors { get; set; }
}

public class CorsSettings
{
    public required string Origins { get; set; }
    public required string Headers { get; set; }
    public required string Methods { get; set; }
}


public class Settings1
{
    public MailAddress[] MailAddress { get; set; }
}

public class MailAddress
{
    public string Address { get; set; }
    public string Display { get; set; }
}