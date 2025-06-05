using be_adminsisters.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace be_adminsisters.UseCases.Users.Commands.LoginUser;

public class LoginUserHandler(IRepository repository) : IRequestHandler<LoginUserCommand>
{
    public async Task Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var isExist = await repository.Users.AnyAsync(x => x.Name == request.Name && x.Password == request.Password,
            cancellationToken);

        if (!isExist)
            throw new KeyNotFoundException("Nie znaleziono podanego użytkownika lub hasło jest nieprawidłowe!");
    }
}