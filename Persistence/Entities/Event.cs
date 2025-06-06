namespace be_adminsisters.Persistence.Entities;

public class Event
{
    public Guid Id { get; init; }
    public string Name { get; set; } = string.Empty;
    public string ShortDescription { get; set; } = string.Empty;
    public string LongDescription { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int CoinReward { get; set; }
    public string Type { get; set; } = string.Empty;
    public List<string> Tags { get; set; } = [];
    public DateTime DateFrom { get; set; }
    public DateTime DateTo { get; set; }
    public Guid LocationId { get; set; }
    public Location? Location { get; init; }

    public static Event Create(
        string name,
        string shortDescription,
        string longDescription,
        decimal price,
        int coinReward,
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
            DateFrom = dateFrom,
            DateTo = dateTo,
            LocationId = locationId
        };
    }
}