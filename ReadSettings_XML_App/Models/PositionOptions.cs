namespace ReadSettings_XML_App.Models;
public class PositionOptions
{
    public const string Position = "Position";

    public string Title { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
}

public class Logging
{
    public const string Position = "Logging:LogLevel";

    public string Default { get; set; } = string.Empty;
    public string Microsoft { get; set; } = string.Empty;
}