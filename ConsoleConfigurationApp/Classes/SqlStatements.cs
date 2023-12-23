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
}