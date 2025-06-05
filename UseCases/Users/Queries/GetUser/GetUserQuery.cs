using be_adminsisters.Common.Models;
using be_adminsisters.UseCases.Users.Dtos;
using MediatR;

namespace be_adminsisters.UseCases.Users.Queries.GetUser;

public record GetUserQuery(Guid Id) : IRequest<ResponseWrapper<UserDto>>;