namespace AdminSisters.Api.Persistence.Entities;

public class Location
{
    private Location() 
    {
    }  
    public Guid Id { get; init; }
    public string Name { get; private set; } = string.Empty;
    public string Address { get; private set; } = string.Empty;
    public double Longitude { get; private set; }
    public double Latitude { get; private set; }

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
