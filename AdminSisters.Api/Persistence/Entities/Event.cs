namespace AdminSisters.Api.Persistence.Entities;

public class Event
{
    public Guid Id { get; init; }
    public string Name { get; private set; } = string.Empty;
    public string ShortDescription { get; private set; } = string.Empty;
    public string LongDescription { get; private set; } = string.Empty;
    public decimal Price { get; private set; }
    public int CoinReward { get; private set; }
    public byte[] Image { get; private set; } = [];
    public string Type { get; private set; } = string.Empty;
    public List<string> Tags { get; private set; } = [];
    public DateTime DateFrom { get; private set; }
    public DateTime DateTo { get; private set; }
    public Guid LocationId { get; private set; }

    public Location? Location { get; init; }

    public static Event Create(
        string name,
        string shortDescription,
        string longDescription,
        decimal price,
        int coinReward,
        byte[] image,
        DateTime dateFrom,
        DateTime dateTo,
        Guid locationId
    )
    {
        return new Event()
        {
            Name = name,
            ShortDescription = shortDescription,
            LongDescription = longDescription,
            Price = price,
            CoinReward = coinReward,
            Image = image,
            DateFrom = dateFrom,
            DateTo = dateTo,
            LocationId = locationId
        };
    }
}
