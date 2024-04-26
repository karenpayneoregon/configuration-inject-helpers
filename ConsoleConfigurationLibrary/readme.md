# About


![Blue Injection64 64](assets/BlueInjection64_64.png)

Provides easy access to connection strings in a Console project's appsettings.json file.

## Example

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