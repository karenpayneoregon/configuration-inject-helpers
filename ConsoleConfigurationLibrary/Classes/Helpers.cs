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
    }
}
