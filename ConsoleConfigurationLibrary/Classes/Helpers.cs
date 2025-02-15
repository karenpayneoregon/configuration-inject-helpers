using Microsoft.Extensions.Configuration;

namespace ConsoleConfigurationLibrary.Classes
{
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
