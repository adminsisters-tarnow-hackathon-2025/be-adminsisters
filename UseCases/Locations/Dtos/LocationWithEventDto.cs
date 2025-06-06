using be_adminsisters.Persistence.Entities;
using be_adminsisters.UseCases.Events.Dtos;

namespace be_adminsisters.UseCases.Locations.Dtos;

public class LocationWithEventDto(Location location)
{
    public Guid Id { get; init; } = location.Id;
    public string Name { get; init; } = location.Name;
    public string Address { get; init; } = location.Address;
    public double Longitude { get; init; } = location.Longitude;
    public double Latitude { get; init; } = location.Latitude;
    public List<SmallEventDto> Events { get; init; } = location.Events.ConvertAll(e => new SmallEventDto(e));
}
