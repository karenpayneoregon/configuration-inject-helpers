using ConsoleConfigurationApp.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using static ConsoleConfigurationLibrary.Classes.AppConnections;

namespace ConsoleConfigurationApp.Classes;
internal class Operations
{
    /// <summary>
    /// Targets Chinook database under SQLEXPRESS
    /// </summary>
    /// <param name="albumId">Identifier of a specific album</param>
    /// <returns></returns>
    public static List<Track> TrackListUsingDapper(int albumId)
    {
        using SqlConnection cn = new(Instance.MainConnection);
        return cn.Query<Track>(SqlStatements.TracksByAlbumId, new { AlbumId = albumId }).ToList();
    }

    public static List<Track> TrackList(int albumId)
    {

        using SqlConnection cn = new(Instance.MainConnection);
        using var cmd = new SqlCommand { Connection = cn, CommandText = SqlStatements.TracksByAlbumId };
        cmd.Parameters.AddWithValue("@AlbumId", albumId);

        List<Track> list = [];

        cn.Open();
        var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            Track track = new()
            {
                TrackId = reader.GetInt32(0),
                Name = reader.GetString(1),
                Milliseconds = reader.GetInt32(2)
            };
            list.Add(track);
        }


        return list;

    }
    /// <summary>
    /// Targets NorthWind2024 database under SQLEXPRESS
    /// </summary>
    /// <returns></returns>
    public static List<Categories> CategoryList()
    {
        using SqlConnection cn = new(Instance.SecondaryConnection);
        return cn.Query<Categories>(SqlStatements.Categories).ToList();
    }

    /// <summary>
    /// Targets ComputedSample3 database under SQLEXPRESS
    /// </summary>
    /// <param name="orderId"></param>
    /// <returns></returns>
    public static List<OrderDetails> OrderDetailsList(int orderId = 3)
    {
        using SqlConnection cn = new(Instance.OtherConnection);
        return cn.Query<OrderDetails>(SqlStatements.OrderDetails, new { OrderId = orderId }).ToList();
    }
}