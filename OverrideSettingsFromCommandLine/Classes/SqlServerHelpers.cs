﻿using Microsoft.Data.SqlClient;

namespace OverrideSettingsFromCommandLine.Classes;
internal class SqlServerHelpers
{
    /// <summary>
    /// Does database exists
    /// </summary>
    /// <param name="databaseName">name of database</param>
    public static bool LocalDbDatabaseExists(string databaseName)
    {
        using var cn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=master;integrated security=True;Encrypt=False");
        using var cmd = new SqlCommand($"SELECT DB_ID('{databaseName}'); ", cn);

        cn.Open();
        return cmd.ExecuteScalar() != DBNull.Value;

    }
}
