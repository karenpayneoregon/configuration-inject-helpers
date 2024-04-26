using System.Runtime.CompilerServices;

// ReSharper disable once CheckNamespace
namespace ReadSettingsApp;
internal partial class Program
{
    [ModuleInitializer]
    public static void Init()
    {
        Console.Title = "Code sample";
        WindowUtility.SetConsoleWindowPosition(WindowUtility.AnchorWindow.Center);
    }

    internal static void WriteLine()
    {
        AnsiConsole.MarkupLine($"[white]{new string('_', 80)}[/]");
    }
}
