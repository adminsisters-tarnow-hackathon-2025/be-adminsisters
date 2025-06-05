using MediatR;

namespace be_adminsisters.UseCases.Users.Commands.DeleteUser;

public record DeleteUserCommand(Guid Id): IRequest;