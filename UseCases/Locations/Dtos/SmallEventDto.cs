using be_adminsisters.Persistence.Entities;

namespace be_adminsisters.UseCases.Locations.Dtos;

public class SmallEventDto(Event eventEntity)
{
    public Guid Id { get; } = eventEntity.Id;
    public string Name { get; } = eventEntity.Name;
}