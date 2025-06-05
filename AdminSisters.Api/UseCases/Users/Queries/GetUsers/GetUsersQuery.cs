using AdminSisters.Api.Common.Models;
using AdminSisters.Api.UseCases.Users.Dtos;
using MediatR;

namespace AdminSisters.Api.UseCases.Users.Queries.GetUsers;

public record GetUsersQuery() : IRequest<ResponseWrapper<IEnumerable<UserDto>>>;