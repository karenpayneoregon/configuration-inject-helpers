using ReadSettings_XML_App.Classes;
using ReadSettings_XML_App.Models;
using static ReadSettings_XML_App.Classes.SpectreConsoleHelpers;

namespace ReadSettings_XML_App;

internal partial class Program
{
    static void Main(string[] args)
    {
        ConnectionStringOptions connections = 
            AppConfigService.ConnectionStrings();

        PositionOptions generalSettings = 
            AppConfigService.GeneralSettings();

        var key = AppConfigService.ApplicationKey();

        Logging appLogging = 
            AppConfigService.ApplicationLogging();
        
        AnsiConsole.MarkupLine("[cyan]Connections[/]");
        Console.WriteLine(ObjectDumper.Dump(connections));

        LineSeparator();

        AnsiConsole.MarkupLine("[cyan]General settings[/]");
        Console.WriteLine(ObjectDumper.Dump(generalSettings));

        LineSeparator();

        AnsiConsole.MarkupLine($"[cyan]Key[/] [yellow]{key}[/]");

        LineSeparator();

        AnsiConsole.MarkupLine("[cyan]Log settings[/]");
        Console.WriteLine(ObjectDumper.Dump(appLogging));

        Console.ReadLine();
    }
}