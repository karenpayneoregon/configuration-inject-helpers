namespace ConsoleConfigurationLibrary.Classes;
/// <summary>
/// Known connection strings
/// </summary>
public sealed class AppConnections
{
    private static readonly Lazy<AppConnections> Lazy = new(() => new AppConnections());
    /// <summary>
    /// Gets the singleton instance of the <see cref="AppConnections"/> class.
    /// </summary>
    /// <remarks>
    /// This property provides a thread-safe, lazily initialized instance of the <see cref="AppConnections"/> class.
    /// Use this instance to access known connection strings throughout the application.
    /// </remarks>
    public static AppConnections Instance => Lazy.Value;
    /// <summary>
    /// Gets or sets the primary connection string used for database operations.
    /// </summary>
    /// <remarks>
    /// This property is typically initialized from the application's configuration settings
    /// and is used as the main connection string for database interactions.
    /// </remarks>
    public string MainConnection { get; set; }
    /// <summary>
    /// Gets or sets the secondary connection string used for database operations.
    /// </summary>
    /// <remarks>
    /// This property is typically configured from application settings and is used
    /// in various database contexts, such as Dapper queries and Entity Framework Core configurations.
    /// </remarks>
    public string SecondaryConnection { get; set; }
    /// <summary>
    /// Gets or sets the connection string for the "OtherConnection" database.
    /// This connection is typically used for accessing the ComputedSample3 database under SQLEXPRESS.
    /// </summary>
    public string OtherConnection { get; set; }
}
