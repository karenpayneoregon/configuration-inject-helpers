using System.Runtime.CompilerServices;


// ReSharper disable once CheckNamespace
namespace ConsoleConfigurationApp;

internal partial class Program
{
    [ModuleInitializer]
    public static void Init()
    {
        Console.Title = "Code sample";
        WindowUtility.SetConsoleWindowPosition(WindowUtility.AnchorWindow.Fill);
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

        table.Columns[0].Alignment(Justify.Right);
        table.Columns[2].Alignment(Justify.Right);

        table.Width = 86;

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

        table.Columns[0].Alignment(Justify.Right);

        table.Width = 86;

        return table;
    }

    public static Table CreateOrdersTable()
    {
        var table = new Table()
            .RoundedBorder()
            .AddColumn("[cyan]Order id[/]")
            .AddColumn("[cyan]Product id[/]")
            .AddColumn("[cyan]Unit price[/]")
            .AddColumn("[cyan]Quantity[/]")
            .AddColumn("[cyan]Row total[/]")
            .AddColumn("[cyan]Product[/]")
            .Alignment(Justify.Left)
            .BorderColor(Color.LightSlateGrey)
            .Title("[LightGreen]Computed[/]");

        table.Columns[0].Alignment(Justify.Right);
        table.Columns[1].Alignment(Justify.Right);
        table.Columns[2].Alignment(Justify.Right);
        table.Columns[3].Alignment(Justify.Right);
        table.Columns[4].Alignment(Justify.Right);

        return table;
    }
}
