﻿namespace KP_WindowsForms.Classes.Configuration;
#nullable disable
/// <summary>
/// Known connection strings
/// </summary>
public sealed class DataConnections
{
    private static readonly Lazy<DataConnections> Lazy = new(() => new DataConnections());
    public static DataConnections Instance => Lazy.Value;

    public string Main { get; set; }
}
