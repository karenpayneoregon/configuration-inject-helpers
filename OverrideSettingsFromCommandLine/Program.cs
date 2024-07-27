using Microsoft.Data.SqlClient;
using OverrideSettingsFromCommandLine.Classes;
using static OverrideSettingsFromCommandLine.Classes.SpectreConsoleHelpers;

namespace OverrideSettingsFromCommandLine;

internal partial class Program
{
    static void Main(string[] args)
    {

        
        // see debug property for command line override of MainConnection
        var mainConnection = Configuration.ConnectionStrings(args);

        SqlConnectionStringBuilder builder = new(mainConnection);

        /*
         * For demonstration purposes, we will check if the database exists
         */
        if (SqlServerHelpers.LocalDbDatabaseExists(builder.InitialCatalog))
        {
            using SqlConnection cn = new() { ConnectionString = mainConnection! };
            cn.Open();
            AnsiConsole.MarkupLine($"[yellow]Current catalog:[/] [cyan]{builder.InitialCatalog}[/] [yellow]opened successfully[/]");
        }
        else
        {
            AnsiConsole.MarkupLine($"[white]Database[/] [red]{builder.InitialCatalog}[/][white] not found![/]");
        }

        
        ExitPrompt();

    }
}