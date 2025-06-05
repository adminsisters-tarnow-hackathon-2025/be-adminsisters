using be_adminsisters.Persistence.Entities;

namespace be_adminsisters.UseCases.Locations.Dtos;

public class LocationDto(Location location)
{
    public Guid Id { get; init; } = location.Id;
    public string Name { get; init; } = location.Name;
}
