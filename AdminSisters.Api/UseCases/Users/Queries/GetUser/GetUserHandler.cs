using AdminSisters.Api.Common.Interfaces;
using AdminSisters.Api.Common.Models;
using AdminSisters.Api.UseCases.Users.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AdminSisters.Api.UseCases.Users.Queries.GetUser;

public class GetUserHandler(IRepository repository) : IRequestHandler<GetUserQuery, ResponseWrapper<UserDto>>
{
    public async Task<ResponseWrapper<UserDto>> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        var user = await repository.Users.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken) 
            ?? throw new KeyNotFoundException("Nie znaleziono podanego użytkownika!");;
        return new ResponseWrapper<UserDto>{ Data = new UserDto(user) };
    }
}