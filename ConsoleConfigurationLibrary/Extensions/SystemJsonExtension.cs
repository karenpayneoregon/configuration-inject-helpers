using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConsoleConfigurationLibrary.Extensions;
/// <summary>
/// Provides extension methods for working with JSON serialization and deserialization using <see cref="System.Text.Json"/>.
/// </summary>
public static class SystemJsonExtension
{
    /// <summary>
    /// Deserializes the specified JSON string into an object of type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type of the object to deserialize to.</typeparam>
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <returns>An object of type <typeparamref name="T"/> deserialized from the JSON string.</returns>
    /// <exception cref="System.ArgumentNullException">
    /// Thrown when <paramref name="jsonString"/> is <c>null</c>.
    /// </exception>
    /// <exception cref="System.Text.Json.JsonException">
    /// Thrown when the JSON string is invalid or cannot be deserialized into the specified type.
    /// </exception>
    public static T JSonToItem<T>(this string jsonString) => JsonSerializer.Deserialize<T>(jsonString);
    /// <summary>
    /// Serializes the specified object of type <typeparamref name="T"/> to a JSON file.
    /// </summary>
    /// <typeparam name="T">The type of the object to serialize.</typeparam>
    /// <param name="sender">The object to serialize.</param>
    /// <param name="fileName">The full path of the file where the JSON content will be written.</param>
    /// <param name="format">
    /// A boolean value indicating whether the JSON output should be formatted (indented). 
    /// Defaults to <c>true</c>.
    /// </param>
    /// <returns>
    /// A tuple containing a boolean result and an exception:
    /// <list type="bullet">
    /// <item>
    /// <description>
    /// <c>result</c>: <c>true</c> if the serialization and file writing were successful; otherwise, <c>false</c>.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <c>exception</c>: The exception that occurred during the process, or <c>null</c> if no exception occurred.
    /// </description>
    /// </item>
    /// </list>
    /// </returns>
    /// <exception cref="System.ArgumentNullException">
    /// Thrown when <paramref name="fileName"/> is <c>null</c> or empty.
    /// </exception>
    /// <exception cref="System.UnauthorizedAccessException">
    /// Thrown when the caller does not have the required permission to write to the specified file.
    /// </exception>
    /// <exception cref="System.IO.IOException">
    /// Thrown when an I/O error occurs during file writing.
    /// </exception>
    /// <exception cref="System.Text.Json.JsonException">
    /// Thrown when the object cannot be serialized to JSON.
    /// </exception>
    public static (bool result, Exception exception) JsonToFile<T>(this T sender, string fileName, bool format = true)
    {
        try
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            File.WriteAllText(fileName, JsonSerializer.Serialize(sender, format ? options : null));

            return (true, null);
        }
        catch (Exception exception)
        {
            return (false, exception);
        }
    }
}
