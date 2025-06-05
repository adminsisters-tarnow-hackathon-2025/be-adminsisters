using be_adminsisters.Common.Interfaces;
using be_adminsisters.Common.Models;
using be_adminsisters.UseCases.Users.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace be_adminsisters.UseCases.Users.Queries.GetUser;

public class GetUserHandler(IRepository repository) : IRequestHandler<GetUserQuery, ResponseWrapper<UserDto>>
{
    public async Task<ResponseWrapper<UserDto>> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        var user = await repository.Users.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken) 
            ?? throw new KeyNotFoundException("Nie znaleziono podanego użytkownika!");
        return new ResponseWrapper<UserDto>{ Data = new UserDto(user) };
    }
}