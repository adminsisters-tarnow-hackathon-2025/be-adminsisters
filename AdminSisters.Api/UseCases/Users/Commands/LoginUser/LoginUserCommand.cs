using MediatR;

namespace AdminSisters.Api.UseCases.Users.Commands.LoginUser;

public record LoginUserCommand(string Name, string Password) : IRequest;