using System.Runtime.CompilerServices;

// ReSharper disable once CheckNamespace
namespace ValidateOnStartSample;
internal partial class Program
{
    [ModuleInitializer]
    public static void Init()
    {
        AnsiConsole.MarkupLine("");
        Console.Title = "Validate on start sample";
        WindowUtility.SetConsoleWindowPosition(WindowUtility.AnchorWindow.Center);
    }
}
