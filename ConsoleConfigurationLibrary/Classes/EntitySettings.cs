namespace ConsoleConfigurationLibrary.Classes;

/// <summary>
/// Represents the settings creating mocked Bogus data.
/// </summary>
public sealed class EntitySettings
{
    private static readonly Lazy<EntitySettings> Lazy = new(() => new EntitySettings());
    /// <summary>
    /// Gets the singleton instance of the <see cref="EntitySettings"/> class, 
    /// which provides configuration settings for creating mocked Bogus data.
    /// </summary>
    /// <value>
    /// The singleton instance of <see cref="EntitySettings"/>.
    /// </value>
    public static EntitySettings Instance => Lazy.Value;

    /// <summary>
    /// Gets or sets a value indicating whether the database should be recreated.
    /// </summary>
    public bool CreateNew { get; set; }
}
