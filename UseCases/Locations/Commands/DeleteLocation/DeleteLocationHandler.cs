using be_adminsisters.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace be_adminsisters.UseCases.Locations.Commands.DeleteLocation;

public class DeleteLocationHandler(IRepository repository) : IRequestHandler<DeleteLocationCommand>
{
    public async Task Handle(DeleteLocationCommand request, CancellationToken cancellationToken)
    {
        var location = await repository.Locations
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
            ?? throw new KeyNotFoundException("Nie znaleziono podanej lokacji!");

        repository.Locations.Remove(location);
        await repository.SaveChangesAsync(cancellationToken);
    }
}
