using be_adminsisters.Persistence.Entities;

namespace be_adminsisters.UseCases.Events.Dtos;

public class EventLocationDto(Location location)
{
    public Guid Id { get; set; } = location.Id;
    public string Name { get; set; } = location.Name;
    public string Address { get; set; } = location.Address;
    public double Longitude { get; set; } = location.Longitude;
    public double Latitude { get; set; } = location.Latitude;
}