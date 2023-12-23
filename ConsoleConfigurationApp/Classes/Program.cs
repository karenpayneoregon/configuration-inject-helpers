using System.Runtime.CompilerServices;


// ReSharper disable once CheckNamespace
namespace ConsoleConfigurationApp;

internal partial class Program
{
    [ModuleInitializer]
    public static void Init()
    {
        AnsiConsole.MarkupLine("");
        Console.Title = "Code sample";
        WindowUtility.SetConsoleWindowPosition(WindowUtility.AnchorWindow.Center);
    }

    public static Table CreateTrackTable()
    {
        var table = new Table()
            .RoundedBorder()
            .AddColumn("[cyan]Id[/]")
            .AddColumn("[cyan]Song[/]")
            .AddColumn("[cyan]Time[/]")
            .Alignment(Justify.Left)
            .BorderColor(Color.LightSlateGrey)
            .Title("[LightGreen]Songs on album[/]");
        return table;
    }
    public static Table CreateCategoryTable()
    {
        var table = new Table()
            .RoundedBorder()
            .AddColumn("[cyan]Id[/]")
            .AddColumn("[cyan]Name[/]")
            .Alignment(Justify.Left)
            .BorderColor(Color.LightSlateGrey)
            .Title("[LightGreen]Categories[/]");
        return table;
    }
}
