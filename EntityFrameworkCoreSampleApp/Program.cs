using ConsoleConfigurationLibrary.Classes;
using EntityFrameworkCoreSampleApp.Data;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCoreSampleApp;

internal partial class Program
{
    static async Task Main(string[] args)
    {
        await RegisterConnectionServices.Configure();
        await using var context = new Context();
        var list = context.Countries.AsNoTracking().ToList();
        foreach (var country in list)
        {
            AnsiConsole.MarkupLine($"[lightcyan3]{country.CountryIdentifier,-5}[/][deepskyblue1]{country.Name}[/]");
        }

        Console.WriteLine();
        AnsiConsole.MarkupLine("[yellow]Press ENTER to quit[/]");
        Console.ReadLine();
    }
}