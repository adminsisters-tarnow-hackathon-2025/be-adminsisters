namespace be_adminsisters.Persistence.Entities;

public class User
{
    private User()
    {
    }

    public Guid Id { get; init; }
    public string Name { get; private set; } = string.Empty;
    public string Password { get; private set; } = string.Empty;
    public int CoinAmount { get; private set; }

    public List<UserEvent>? UserEvents { get; init; }
    public List<UserAchievement>? UserAchievements { get; init; }

    public static User Create(
        string name,
        string password
    )
    {
        return new User()
        {
            Name = name,
            Password = password
        };
    }

    public void AddCoin(int amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Amount must be greater than zero.", nameof(amount));

        CoinAmount += amount;
    }

    public void RemoveCoin(int amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Amount must be greater than zero.", nameof(amount));

        CoinAmount -= amount;
    }
    
    
}