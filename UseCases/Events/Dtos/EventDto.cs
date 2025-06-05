using be_adminsisters.Persistence.Entities;

namespace be_adminsisters.UseCases.Events.Dtos;

public class EventDto(Event eventEntity)
{
    public Guid Id { get; set; } = eventEntity.Id;
    public string Name { get; set; } = eventEntity.Name;
    public string ShortDescription { get; set; } = eventEntity.ShortDescription;
    public string LongDescription { get; set; } = eventEntity.LongDescription;
    public decimal Price { get; set; } = eventEntity.Price;
    public int CoinReward { get; set; } = eventEntity.CoinReward;
    public byte[] Image { get; set; } = eventEntity.Image;
    public DateTime DateFrom { get; set; } = eventEntity.DateFrom;
    public DateTime DateTo { get; set; } = eventEntity.DateTo;
    public Guid LocationId { get; set; } = eventEntity.LocationId;
}
