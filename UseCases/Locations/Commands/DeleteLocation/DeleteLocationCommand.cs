using MediatR;

namespace be_adminsisters.UseCases.Locations.Commands.DeleteLocation;

public record DeleteLocationCommand(Guid Id) : IRequest;
