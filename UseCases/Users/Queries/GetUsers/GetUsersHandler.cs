using be_adminsisters.Common.Interfaces;
using be_adminsisters.Common.Models;
using be_adminsisters.UseCases.Users.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace be_adminsisters.UseCases.Users.Queries.GetUsers;

public class GetUsersHandler(IRepository repository) : IRequestHandler<GetUsersQuery, ResponseWrapper<IEnumerable<UserDto>>>
{
    public async Task<ResponseWrapper<IEnumerable<UserDto>>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        var users = await repository.Users.ToListAsync(cancellationToken);
        return new ResponseWrapper<IEnumerable<UserDto>> { Data = users.Select(x => new UserDto(x)) };
    }
}