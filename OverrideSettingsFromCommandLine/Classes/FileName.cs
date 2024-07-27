namespace OverrideSettingsFromCommandLine.Classes;

internal class FileName
{
    public FileName()
    {
        House house = House.Builder()
            .WithAddress("123 Main St")
            .WithNumberOfRooms(3)
            .WithGarage(true)
            .Build();

        var garage = house.HasGarage ? "has a garage" : "does not have a garage";
        Console.WriteLine($"The house at {house.Address} has {house.NumberOfRooms} rooms and {garage}.");
        
    }
}

/// <summary>
/// Represents a house.
/// </summary>
public class House
{
    private string _address;
    private int _numberOfRooms;
    private bool _hasGarage;

    public string Address => _address;
    public int NumberOfRooms => _numberOfRooms;
    public bool HasGarage => _hasGarage;

    private House()
    {
        // Private constructor to enforce the use of the builder pattern
    }

    /// <summary>
    /// Creates a new instance of the HouseBuilder.
    /// </summary>
    /// <returns>The HouseBuilder instance.</returns>
    public static HouseBuilder Builder()
    {
        return new HouseBuilder();
    }

    /// <summary>
    /// Represents a builder for the House class.
    /// </summary>
    public class HouseBuilder
    {
        private protected House _house = new();

        /// <summary>
        /// Sets the address of the house.
        /// </summary>
        /// <param name="address">The address of the house.</param>
        /// <returns>The HouseBuilder instance.</returns>
        public HouseBuilder WithAddress(string address)
        {
            _house._address = address;
            return this;
        }

        /// <summary>
        /// Sets the number of rooms in the house.
        /// </summary>
        /// <param name="numberOfRooms">The number of rooms in the house.</param>
        /// <returns>The HouseBuilder instance.</returns>
        public HouseBuilder WithNumberOfRooms(int numberOfRooms)
        {
            _house._numberOfRooms = numberOfRooms;
            return this;
        }

        /// <summary>
        /// Sets whether the house has a garage.
        /// </summary>
        /// <param name="hasGarage">True if the house has a garage, false otherwise.</param>
        /// <returns>The HouseBuilder instance.</returns>
        public HouseBuilder WithGarage(bool hasGarage)
        {
            _house._hasGarage = hasGarage;
            return this;
        }

        /// <summary>
        /// Builds the house.
        /// </summary>
        /// <returns>The built House instance.</returns>
        public House Build()
        {
            return _house;
        }
    }
}
