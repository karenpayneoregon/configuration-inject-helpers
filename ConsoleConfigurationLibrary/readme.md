# About


![Blue Injection64 64](assets/BlueInjection64_64.png)

Provides easy access to connection strings in a Console project's appsettings.json file.

01/2025 - Updated external NuGet packages

02/2025 Added 
- Overload for `Configuration.JsonRoot` which accepts a json file rather than the base method which is hard coded to appsettings.json. The overload is for testing.
- Helpers class

## Connect Example

With the following appsettings.json file

```json
{
  "ConnectionStrings": {
    "MainConnection": "Data Source=.\\SQLEXPRESS;Initial Catalog=Chinook;Integrated Security=True;Encrypt=False",
    "SecondaryConnection": "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=NorthWind2024;Integrated Security=True;Encrypt=False",
    "OtherConnection": "Other"
  }
}
```

Add this package to a console project then in Program.cs, call `RegisterConnectionServices.Configure()`

```csharp
static async Task Main(string[] args)
{

    await RegisterConnectionServices.Configure();
    Console.ReadLine();
}
```

To access the MainConnectionString use `AppConnections.Instance.MainConnection` as shown below, in this case using Dapper.

```csharp
public static List<Track> TrackList(int albumId)
{
    using SqlConnection cn = new(AppConnections.Instance.MainConnection);
    return cn.Query<Track>(SqlStatements.TracksByAlbumId, new { AlbumId = albumId }).ToList();
}
```

Then for the second connection string

```csharp
public static List<Categories> CategoryList()
{
    using SqlConnection cn = new(AppConnections.Instance.SecondaryConnection);
    return cn.Query<Categories>(SqlStatements.Categories).ToList();
}
```

And Other connection string follows the same as both of the above.

## Working code samples

See the project ConsoleConfigurationApp.

- Run the scripts under the script folder before run the project.

## Release notes

- 04/26/2024 no functionality change, simple refactor.

---

# Class documentation

## Summary of the `AppConnections` Class

The AppConnections class is a sealed singleton class designed to manage known connection strings in a thread-safe and lazily initialized manner. It is part of the ConsoleConfigurationLibrary.Classes namespace.

### Key Features:

- Singleton Pattern: 

  - The class uses a Lazy<T> instance to ensure thread-safe, lazy initialization of the singleton instance.

  - Access the singleton instance via the static Instance property.

- Properties:

  - MainConnection: A string property to store the main connection string.

  - SecondaryConnection: A string property to store a secondary connection string.

  - OtherConnection: A string property to store another connection string.

## Summary of the `ApplicationConfiguration` Class

The ApplicationConfiguration class is part of the ConsoleConfigurationLibrary.Classes namespace and is responsible for configuring application services, including dependency injection and configuration bindings for connection strings and entity settings.

### Key Features:

- Service Configuration:

  - Provides a static method ConfigureServices to set up application services.

  - Configures services using IServiceCollection to bind connection strings and entity settings from appsettings.json.

- Dependency Injection:

  - Adds transient services like SetupServices to the service collection.

  - Ensures proper initialization of services before the application starts.

  ## Summary of the `ApplicationValidation` Class

The ApplicationValidation class is part of the ConsoleConfigurationLibrary.Classes namespace. It provides functionality to validate application configuration during startup, ensuring that essential configuration sections are present and properly configured.

### Key Features:

- Startup Validation:

  - Ensures that critical configuration sections, such as connection strings, are properly set up when the application starts.

  - Throws exceptions if required configurations are missing or invalid.

- Validation Methods:

  - ValidateOnStart(): Validates the presence and correctness of the "ConnectionStrings" section and its main connection string.

  - ValidateOnStart<T>(string sectionName, Expression<Func<T, string>> propertySelector): Validates a specific configuration section and a property within it, ensuring they are properly configured.

- Helper Method:

  - GetPropertyName<T>(Expression<Func<T, string>> propertySelector): Retrieves the name of a property specified in an expression, used for validation purposes.

## Summary of the `CommandLineOverride` Class

The CommandLineOverride class is part of the ConsoleConfigurationLibrary.Classes namespace. It provides functionality to override application configuration settings using command-line arguments.

### Key Features:

- Configuration Building:

  - The class includes a static method BuilderRoot to build a configuration root by combining settings from multiple sources, including:

    - appsettings.json

    - Environment variables

    - Command-line arguments (if provided)

- Command-Line Integration:

  - Supports overriding configuration values using command-line arguments, enabling dynamic configuration changes at runtime.

## Summary of the `Configuration` Class

The Configuration class is part of the ConsoleConfigurationLibrary.Classes namespace. It provides functionality to manage and access application configuration settings, including reading configuration files and retrieving configuration roots.

### Key Features:

- Configuration Root Access:

  - Provides a static method JsonRoot to retrieve the root of the configuration, which is built from the appsettings.json file.

- Configuration File Handling:

  - Reads and processes the appsettings.json file to provide access to application settings.

## Summary of the `Connection` Class (WIP)

The Connection class is part of the ConsoleConfigurationLibrary.Classes namespace. It provides functionality to validate and manage database connection strings, ensuring they are properly formatted and usable.

### Key Features:

- Connection String Validation:

  - Includes a static method Validator to validate the format and usability of a connection string.

  - Throws exceptions if the connection string is null, empty, or improperly formatted.

## Summary of the `ConnectionHelpers` Class

The ConnectionHelpers class is part of the ConsoleConfigurationLibrary.Classes namespace. It provides utility methods to assist with connection string-related operations, such as checking the existence of configuration sections.

### Key Features:

- Configuration Section Check:

  - Includes a static method MainConnectionStringsSectionExist to verify whether the "ConnectionStrings" section exists in the application's configuration.

## Summary of the `EntitySettings` Class (needs to move to Models folder)

The EntitySettings class is part of the ConsoleConfigurationLibrary.Classes namespace. It represents a configuration model for entity-related settings, typically used to map configuration data from appsettings.json or other configuration sources.

### Key Features:

- Configuration Properties:

  - Name: A string property representing the name of the entity.

  - Description: A string property representing the description of the entity.

- Purpose:

  - This class is designed to hold entity-specific settings, which can be bound from configuration files using dependency injection or configuration binding.

## Summary of the `Helpers` Class

The Helpers class is part of the ConsoleConfigurationLibrary.Classes namespace. It provides utility methods for working with application configuration settings, such as checking for the existence of configuration sections and retrieving strongly-typed configuration values.

### Key Features:

- Configuration Section Check:

  - SectionExists(string sectionName): Checks whether a configuration section with the specified name exists in the application's configuration.

- Retrieve Configuration Values:

  - GetSetting1<T>(string section, string name): Retrieves a strongly-typed value from the application configuration based on the specified section and name. Returns the default value of the type if the setting is not found or an error occurs.

  - GetSetting<T>(string section, string name): Similar to GetSetting1, retrieves a strongly-typed value from the specified configuration section and key.

## Summary of the `RegisterConnectionServices` Class

The RegisterConnectionServices class is a static class in the ConsoleConfigurationLibrary.Classes namespace. It provides functionality to register and configure connection-related services for applications.

### Key Features:

- Service Configuration:

  - The class includes a static method Configure to set up and initialize required services and read connection strings.

- Integration with Dependency Injection:

  - Uses the ApplicationConfiguration.ConfigureServices method to configure the service collection.

  - Builds a service provider to resolve and initialize services.

- Connection String Initialization:

  - Retrieves connection strings using the SetupServices.GetConnectionStrings method.

## Summary of the `SetupServices` Class

The SetupServices class is part of the ConsoleConfigurationLibrary.Classes namespace. It provides methods to configure and retrieve application settings, such as connection strings and entity configurations, from the application's configuration files.

### Key Features:

1. Dependency Injection:

   - The class is designed to work with dependency injection, taking in IOptions<T> for configuration models like ConnectionStrings and EntityConfiguration.

2. Connection String Management:

   - The GetConnectionStrings method reads connection strings from the application's configuration and assigns them to the singleton AppConnections instance.

3. Entity Settings Management:

   - The GetEntitySettings method retrieves entity-related settings from the application's configuration and assigns them to the singleton EntitySettings instance.

4. Service Setup:

   - The static Setup method configures and initializes application services, including connection strings and entity settings, by reading from the application's configuration files.