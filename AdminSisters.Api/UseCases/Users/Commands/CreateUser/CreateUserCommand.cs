using AdminSisters.Api.Common.Models;
using MediatR;

namespace AdminSisters.Api.UseCases.Users.Commands.CreateUser;

public record CreateUserCommand(string Name, string Password) : IRequest<ResponseWrapper<Guid>>;