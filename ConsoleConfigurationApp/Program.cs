using ConsoleConfigurationApp.Classes;
using ConsoleConfigurationLibrary.Classes;

namespace ConsoleConfigurationApp;

internal partial class Program
{

    static async Task Main(string[] args)
    {

        await RegisterConnectionServices.Configure();
       

        MainConnectionExample();
        SecondConnectionExample();
        OtherConnectionExample();

        Console.ReadLine();
    }

    private static void MainConnectionExample()
    {
        var list = Operations.TrackList(129);
        var trackTable = CreateTrackTable();

        foreach (var track in list)
        {
            trackTable.AddRow(track.TrackId.ToString(), track.Name, track.Milliseconds.ShowTime());
        }

        AnsiConsole.Write(trackTable);
    }

    private static void SecondConnectionExample()
    {
        var categoryTable = CreateCategoryTable();
        var categories = Operations.CategoryList();

        foreach (var category in categories)
        {
            categoryTable.AddRow(category.CategoryID.ToString(), category.CategoryName);
        }

        AnsiConsole.Write(categoryTable);
    }

    private static void OtherConnectionExample()
    {
        var list = Operations.OrderDetailsList();
        var table = CreateOrdersTable();
        
        foreach (var item in list)
        {
            table.AddRow(
                item.OrderId.ToString(), 
                item.ProductId.ToString(), 
                item.UnitPrice.ToString("C"),
                item.Quantity.ToString(), 
                item.RowTotal.ToString("C"), 
                item.ProductName);
        }

        AnsiConsole.Write(table);
    }
}

