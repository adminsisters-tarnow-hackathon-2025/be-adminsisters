using be_adminsisters.Common.Interfaces;
using be_adminsisters.Common.Models;
using be_adminsisters.UseCases.Users.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace be_adminsisters.UseCases.Users.Commands.LoginUser;

public class LoginUserHandler(IRepository repository) : IRequestHandler<LoginUserCommand, ResponseWrapper<UserDto>>
{
    public async Task<ResponseWrapper<UserDto>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var user = await repository.Users
            .FirstOrDefaultAsync(x => x.Name == request.Name, cancellationToken)
            ?? throw new KeyNotFoundException("Nieprawidłowe dane logowania!");

        return new ResponseWrapper<UserDto>() { Data = new UserDto(user) };
    }
}