using ConsoleConfigurationApp.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using static ConsoleConfigurationLibrary.Classes.AppConnections;

namespace ConsoleConfigurationApp.Classes;
internal class Operations
{
    public static List<Track> TrackList(int albumId)
    {
        using SqlConnection cn = new(Instance.MainConnection);
        return cn.Query<Track>(SqlStatements.TracksByAlbumId, new { AlbumId = albumId }).ToList();
    }

    public static List<Categories> CategoryList()
    {
        using SqlConnection cn = new(Instance.SecondaryConnection);
        return cn.Query<Categories>(SqlStatements.Categories).ToList();
    }
    public static List<OrderDetails> OrderDetailsList(int orderId = 3)
    {
        using SqlConnection cn = new(Instance.OtherConnection);
        return cn.Query<OrderDetails>(SqlStatements.OrderDetails, new { OrderId = orderId }).ToList();
    }
}