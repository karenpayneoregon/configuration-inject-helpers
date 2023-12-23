using ConsoleConfigurationApp.Models;
using ConsoleConfigurationLibrary.Classes;
using Dapper;
using Microsoft.Data.SqlClient;

namespace ConsoleConfigurationApp.Classes;
internal class Operations
{
    public static List<Track> TrackList(int albumId)
    {
        using SqlConnection cn = new(AppConnections.Instance.MainConnection);
        return cn.Query<Track>(SqlStatements.TracksByAlbumId, new { AlbumId = albumId }).ToList();
    }

    public static List<Categories> CategoryList()
    {
        using SqlConnection cn = new(AppConnections.Instance.SecondaryConnection);
        return cn.Query<Categories>(SqlStatements.Categories).ToList();
    }
}