using be_adminsisters.Common.Interfaces;
using be_adminsisters.Common.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace be_adminsisters.UseCases.Users.Commands.LoginUser;

public class LoginUserHandler(IRepository repository) : IRequestHandler<LoginUserCommand, ResponseWrapper<Guid>>
{
    public async Task<ResponseWrapper<Guid>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var user = await repository.Users
            .FirstOrDefaultAsync(x => x.Name == request.Name, cancellationToken)
            ?? throw new KeyNotFoundException("Nieprawidłowe dane logowania!");

        return new ResponseWrapper<Guid>() { Data = user.Id };
    }
}