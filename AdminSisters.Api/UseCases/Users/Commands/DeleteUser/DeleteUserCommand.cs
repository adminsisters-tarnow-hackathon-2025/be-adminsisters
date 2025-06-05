using MediatR;

namespace AdminSisters.Api.UseCases.Users.Commands.DeleteUser;

public record DeleteUserCommand(Guid Id): IRequest;