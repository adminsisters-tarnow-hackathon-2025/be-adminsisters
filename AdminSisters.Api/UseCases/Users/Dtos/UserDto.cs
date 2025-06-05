using AdminSisters.Api.Persistence.Entities;

namespace AdminSisters.Api.UseCases.Users.Dtos;

public class UserDto(User user)
{
    public Guid Id { get; init; } = user.Id;
    public string Name { get; init; } = user.Name;
    public int CoinAmount { get; init; } = user.CoinAmount;
}