using AdminSisters.Api.Common.Interfaces;
using AdminSisters.Api.Common.Models;
using AdminSisters.Api.UseCases.Users.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AdminSisters.Api.UseCases.Users.Queries.GetUsers;

public class GetUsersHandler(IRepository repository) : IRequestHandler<GetUsersQuery, ResponseWrapper<IEnumerable<UserDto>>>
{
    public async Task<ResponseWrapper<IEnumerable<UserDto>>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        var users = await repository.Users.ToListAsync(cancellationToken);
        return new ResponseWrapper<IEnumerable<UserDto>> { Data = users.Select(x => new UserDto(x)) };
    }
}