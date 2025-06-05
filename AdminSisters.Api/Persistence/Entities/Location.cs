namespace AdminSisters.Api.Persistence.Entities;

public class Location
{
    public Guid Id { get; init; }
    public string Name { get; private set; } = string.Empty;
    public string Address { get; private set; } = string.Empty;
    public double Longitude { get; private set; }
    public double Latitude { get; private set; }

    public List<Event> Events { get; init; } = [];
}
