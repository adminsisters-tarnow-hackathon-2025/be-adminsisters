using AdminSisters.Api.UseCases.Users.Commands.CreateUser;

namespace AdminSisters.Api.Persistence.Entities;

public class User
{
    public Guid Id { get; init; }
    public string Name { get; private set; } = string.Empty;
    public string Password { get; private set; } = string.Empty;
    public int CoinAmount { get; private set; }

    private User()
    {
        
    }

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