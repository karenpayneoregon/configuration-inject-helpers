namespace ConsoleConfigurationLibrary.Models;
/// <summary>
/// For application connection strings
/// </summary>
public class ConnectionStrings
{
    /// <summary>
    /// Gets or sets the primary connection string used by the application.
    /// </summary>
    public string MainConnection { get; set; }
    /// <summary>
    /// Gets or sets the secondary connection string used by the application.
    /// </summary>
    public string SecondaryConnection { get; set; }
    /// <summary>
    /// Gets or sets an additional connection string for the application.
    /// </summary>
    public string OtherConnection { get; set; }
}


