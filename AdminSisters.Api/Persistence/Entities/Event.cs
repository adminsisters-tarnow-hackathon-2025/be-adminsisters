namespace AdminSisters.Api.Persistence.Entities;

public class Event
{
    public Guid Id { get; init; }
    public string Name { get; private set; } = string.Empty;
    public string ShortDescription { get; private set; } = string.Empty;
    public string LongDescription { get; private set; } = string.Empty;
    public decimal Price { get; private set; }
    public decimal CoinReward { get; private set; }
    public byte[] Image { get; private set; } = Array.Empty<byte>();
    public DateTime DateFrom { get; private set; }
    public DateTime DateTo { get; private set; }
    public Guid LocationId { get; private set; }

    public Location? Location { get; init; }
}
