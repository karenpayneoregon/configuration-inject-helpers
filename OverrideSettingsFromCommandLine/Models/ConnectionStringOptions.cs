namespace OverrideSettingsFromCommandLine.Models;

public class ConnectionStringOptions
{
    public const string Position = "ConnectionString";
    public string Production { get; set; } = string.Empty;
    public string Development { get; set; } = string.Empty;
}




