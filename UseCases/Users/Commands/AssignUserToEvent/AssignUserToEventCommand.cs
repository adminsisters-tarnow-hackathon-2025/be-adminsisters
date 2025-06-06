using MediatR;

namespace be_adminsisters.UseCases.Users.Commands.AssignUserToEvent;

public record AssignUserToEventCommand(Guid UserId, Guid EventId) : IRequest;
