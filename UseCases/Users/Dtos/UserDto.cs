using be_adminsisters.Persistence.Entities;

namespace be_adminsisters.UseCases.Users.Dtos;

public class UserDto(User user)
{
    public Guid Id { get; init; } = user.Id;
    public string Name { get; init; } = user.Name;
    public int CoinAmount { get; init; } = user.CoinAmount;
    public bool IsAdmin { get; init; } = user.IsAdmin;
}