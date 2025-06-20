﻿namespace be_adminsisters.Persistence.Entities;

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
    public string Image { get; set; } = string.Empty;
    public Guid LocationId { get; set; }
    public Location? Location { get; init; }

    public static Event Create(
        string name,
        string shortDescription,
        string longDescription,
        string type,
        decimal price,
        int coinReward,
        List<string> tags,
        DateTime dateFrom,
        DateTime dateTo,
        string image,
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
            Type = type,
            Tags = tags,
            DateFrom = dateFrom.Kind == DateTimeKind.Unspecified ? DateTime.SpecifyKind(dateFrom, DateTimeKind.Utc) : dateFrom.ToUniversalTime(),
            DateTo = dateTo.Kind == DateTimeKind.Unspecified ? DateTime.SpecifyKind(dateTo, DateTimeKind.Utc) : dateTo.ToUniversalTime(),
            Image = image,
            LocationId = locationId
        };
    }
}