using AdminSisters.Api.Common.Models;
using AdminSisters.Api.UseCases.Users.Dtos;
using MediatR;

namespace AdminSisters.Api.UseCases.Users.Queries.GetUser;

public record GetUserQuery(Guid Id) : IRequest<ResponseWrapper<UserDto>>;