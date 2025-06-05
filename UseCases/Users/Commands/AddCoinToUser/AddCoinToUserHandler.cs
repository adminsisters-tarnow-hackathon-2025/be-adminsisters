using be_adminsisters.Common.Interfaces;
using be_adminsisters.Common.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace be_adminsisters.UseCases.Users.Commands.AddCoinToUser;

public class AddCoinToUserHandler(IRepository repository) : IRequestHandler<AddCoinToUserCommand, ResponseWrapper<int>>
{
    public async Task<ResponseWrapper<int>> Handle(AddCoinToUserCommand request, CancellationToken cancellationToken)
    {
        var user = await repository.Users.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
                   ?? throw new KeyNotFoundException("Nie znaleziono podanego użytkownika!");
        user.AddCoin(request.Options.Amount);
        await repository.SaveChangesAsync(cancellationToken);
        return new ResponseWrapper<int> { Data = user.CoinAmount };
    }
}