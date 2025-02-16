using Microsoft.Extensions.Configuration;

namespace ConsoleConfigurationLibrary.Classes
{
    /// <summary>
    /// Provides helper methods for working with application configuration settings.
    /// </summary>
    /// <remarks>
    /// This class includes utility methods to facilitate interaction with configuration sections,
    /// such as checking for the existence of specific configuration sections.
    /// </remarks>
    public class Helpers
    {
        /// <summary>
        /// Checks whether a configuration section with the specified name exists in the application's configuration.
        /// </summary>
        /// <param name="sectionName">The name of the configuration section to check for existence.</param>
        /// <returns>
        /// <c>true</c> if the configuration section exists; otherwise, <c>false</c>.
        /// </returns>
        public static bool SectionExists(string sectionName) 
            => Configuration.JsonRoot().GetSection(sectionName).Exists();

        /// <summary>
        /// Retrieves a strongly-typed value from the application configuration based on the specified section and name.
        /// </summary>
        /// <typeparam name="T">
        /// The type of the value to retrieve. Must have a parameterless constructor.
        /// </typeparam>
        /// <param name="section">
        /// The name of the configuration section containing the desired setting.
        /// </param>
        /// <param name="name">
        /// The name of the setting within the specified section.
        /// </param>
        /// <returns>
        /// The value of the specified setting as type <typeparamref name="T"/> if found; otherwise, the default value of <typeparamref name="T"/>.
        /// </returns>
        /// <remarks>
        /// If the specified section or name is invalid, or if an error occurs during retrieval, the method returns the default value of <typeparamref name="T"/>.
        /// </remarks>
        /// <example>
        /// <code>
        /// var createNewValue = GetSetting&lt;bool&gt;(nameof(EntityConfiguration), nameof(EntityConfiguration.CreateNew));
        /// </code>
        /// </example>
        public static T GetSetting<T>(string section, string name) where T : new()
        {
            if (string.IsNullOrWhiteSpace(name)) return default(T);

            try
            {
                return Configuration.JsonRoot().GetSection(section).GetValue<T>(name);
            }
            catch
            {
                return default(T); // TODO:
            }
        }
    }
}
