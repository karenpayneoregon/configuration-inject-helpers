using ConsoleConfigurationLibrary.Classes;
using ConsoleConfigurationLibrary.Models;

namespace ValidateOnStartSample;

internal partial class Program
{
    static void Main(string[] args)
    {
        try
        {
            ApplicationValidation.ValidateOnStart<DatabaseSettings>(nameof(DatabaseSettings), 
                    settings => settings.ConnectionString);

            Console.WriteLine("Configuration is valid.");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Configuration validation failed: {ex.Message}");
        }
        AnsiConsole.MarkupLine("[yellow]Hello[/]");
        Console.ReadLine();
    }
}

public class DatabaseSettings
{
    public string ConnectionString { get; set; }
}
