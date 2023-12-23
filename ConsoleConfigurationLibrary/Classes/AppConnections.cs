namespace ConsoleConfigurationLibrary.Classes;
/// <summary>
/// Known connection strings
/// </summary>
public sealed class AppConnections
{
    private static readonly Lazy<AppConnections> Lazy = new(() => new AppConnections());
    public static AppConnections Instance => Lazy.Value;
    public string MainConnection { get; set; }
    public string SecondaryConnection { get; set; }
    public string OtherConnection { get; set; }
}
