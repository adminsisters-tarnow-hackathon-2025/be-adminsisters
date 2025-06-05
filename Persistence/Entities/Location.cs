namespace be_adminsisters.Persistence.Entities;

public class Location
{
    private Location()
    {
    }

    public Guid Id { get; init; }
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public double Longitude { get; set; }
    public double Latitude { get; set; }

    public List<Event> Events { get; init; } = [];

    public static Location Create(
        string name,
        string address,
        double longitude,
        double latitude
    )
    {
        return new Location()
        {
            Name = name,
            Address = address,
            Longitude = longitude,
            Latitude = latitude
        };
    }
}