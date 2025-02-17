using ConsoleConfigurationLibrary.Models;
using Microsoft.Extensions.Configuration;
using static ConsoleConfigurationLibrary.Classes.Configuration;

#pragma warning disable CS1574, CS1584, CS1581, CS1580


namespace ConsoleConfigurationLibrary.Classes
{
    /// <summary>
    /// Provides helper methods for working with configuration sections in the application's configuration.
    /// </summary>
    /// <remarks>
    /// This class includes utility methods to simplify the process of checking for the existence of 
    /// specific configuration sections in JSON configuration files or other configuration sources.
    /// </remarks>
    public class ConnectionHelpers
    {
        /// <summary>
        /// Checks whether a specified configuration section exists in the application's configuration.
        /// </summary>
        /// <param name="sectionName">
        /// The name of the configuration section to check for existence.
        /// </param>
        /// <returns>
        /// <c>true</c> if the specified configuration section exists; otherwise, <c>false</c>.
        /// </returns>
        /// <remarks>
        /// This method retrieves the specified section from the application's JSON configuration
        /// and determines its existence using the <see cref="IConfigurationSection.GetSection"/> method.
        /// </remarks>
        public static bool SectionExists(string sectionName)
            => JsonRoot().GetSection(sectionName).Exists();

        /// <summary>
        /// Checks whether the "ConnectionStrings" section exists in the application's configuration.
        /// </summary>
        /// <returns>
        /// <c>true</c> if the "ConnectionStrings" section exists; otherwise, <c>false</c>.
        /// </returns>
        /// <remarks>
        /// This method verifies the existence of the "ConnectionStrings" section in the application's JSON configuration
        /// using the <see cref="IConfigurationSection.Exists"/> method.
        /// </remarks>
        public static bool MainConnectionStringsSectionExist()
            => JsonRoot().GetSection(nameof(ConnectionStrings)).Exists();
    }
}
