using be_adminsisters.Common.Models;
using MediatR;

namespace be_adminsisters.UseCases.Users.Commands.CreateUser;

public record CreateUserCommand(string Name, string Password) : IRequest<ResponseWrapper<Guid>>;