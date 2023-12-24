namespace ConsoleConfigurationApp.Classes;

public class SqlStatements
{
    public static string TracksByAlbumId => 
        """
        SELECT TrackId,
               [Name],
               Milliseconds
        FROM dbo.Track
        WHERE AlbumId = @AlbumId;
        """;

    public static string Categories => 
        """
        SELECT CategoryID,
               CategoryName,
               [Description],
               Picture
        FROM dbo.Categories;
        """;

    public static string OrderDetails =>
        """
        SELECT od.OrderId,
               od.ProductId,
               od.UnitPrice,
               od.Quantity,
               od.RowTotal,
               p.ProductName
        FROM dbo.OrderDetails AS od
            INNER JOIN dbo.Products AS p
                ON od.ProductId = p.ProductID
        WHERE (od.OrderId = @OrderId);
        """;
}