using ConsoleApp1.Models;
using ConsoleConfigurationLibrary.Classes;
using Microsoft.Extensions.Configuration;
using Spectre.Console;

namespace ConsoleApp1;

internal class Program
{
    static void Main(string[] args)
    {
        // Validate ConnectionStrings properties on start
        var (valid, errors) = ApplicationValidation.ValidateOnStartReporter<ConnectionStrings>(nameof(ConnectionStrings),
            cs => cs.MainConnection,
            cs => cs.SecondaryConnection
        );
        if (!valid)
        {
            AnsiConsole.MarkupLine("[red]Validation failed:[/]");
            foreach (var error in errors)
            {
                Console.WriteLine($"   {error}");
            }
        }
        else
        {
            AnsiConsole.MarkupLine($"[{Color.Pink1}]Validation succeeded.[/]");
        }


        Console.WriteLine("Done");
        Console.ReadLine();
    }
}
