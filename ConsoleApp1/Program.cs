using ConsoleConfigurationLibrary.Classes;
using Microsoft.Extensions.Configuration;
namespace ConsoleApp1;

internal class Program
{
    static void Main(string[] args)
    {
        var _configuration = Configuration.JsonRoot();

        var serverUrl = _configuration.GetValue<string>("Serilog:WriteTo:0:Args:serverUrl");
        Console.WriteLine("Hello, World!");
    }
}
