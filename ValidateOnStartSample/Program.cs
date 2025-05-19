using ConsoleConfigurationLibrary.Classes;
using ConsoleConfigurationLibrary.Models;

namespace ValidateOnStartSample;

internal partial class Program
{
    private static void Main(string[] args)
    {
        try
        {
            ApplicationValidation.ValidateOnStart<DatabaseSettings>(nameof(DatabaseSettings), 
                    settings => settings.ConnectionString);

            AnsiConsole.MarkupLine("[green]Configuration is valid.[/]");
        }
        catch (InvalidOperationException ex)
        {
            AnsiConsole.MarkupLine($"[red]Configuration validation failed:[/] [cyan]{ex.Message}[/]");
        }
        AnsiConsole.MarkupLine("[yellow]Exit[/]");
        Console.ReadLine();
    }
}

public class DatabaseSettings
{
    public string ConnectionString { get; set; }
}
