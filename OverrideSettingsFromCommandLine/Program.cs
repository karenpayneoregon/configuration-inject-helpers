using ConsoleConfigurationLibrary.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using static ConsoleConfigurationLibrary.Classes.CommandLineOverride;

namespace OverrideSettingsFromCommandLine;

internal partial class Program
{
    static void Main(string[] args)
    {

        // see debug property for command line override of MainConnection
        string mainConnection = BuilderRoot(args).GetConnectionString(
            nameof(ConnectionStrings.MainConnection));

        // Yep we can create and examine connections
        SqlConnectionStringBuilder builder = new(mainConnection);
        
        using SqlConnection cn = new() { ConnectionString = mainConnection! };
        cn.Open();


        AnsiConsole.MarkupLine($"[cyan]{builder.InitialCatalog}[/]");

        Console.ReadLine();
    }
}