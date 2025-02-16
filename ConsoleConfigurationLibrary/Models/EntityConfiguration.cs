namespace ConsoleConfigurationLibrary.Models;
/// <summary>
/// Represents the configuration settings for an entity within the application.
/// </summary>
public class EntityConfiguration
{
    /// <summary>
    /// Should a table be populated with new data using the Bogus library or
    /// use existing data.
    /// </summary>
    /// <remarks>
    /// Setting read from appsettings.json
    /// </remarks>
    public bool CreateNew { get; set; }
}
