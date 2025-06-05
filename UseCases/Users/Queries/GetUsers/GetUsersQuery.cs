using be_adminsisters.Common.Models;
using be_adminsisters.UseCases.Users.Dtos;
using MediatR;

namespace be_adminsisters.UseCases.Users.Queries.GetUsers;

public record GetUsersQuery() : IRequest<ResponseWrapper<IEnumerable<UserDto>>>;