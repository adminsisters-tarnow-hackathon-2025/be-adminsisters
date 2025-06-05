using be_adminsisters.Common.Extensions;
using be_adminsisters.Common.Interfaces;
using be_adminsisters.Common.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace be_adminsisters.UseCases.Locations.Commands.UpdateLocation;

public class UpdateUserHandler(IRepository repository) : IRequestHandler<UpdateLocationCommand, ResponseWrapper<Guid>>
{
    public async Task<ResponseWrapper<Guid>> Handle(UpdateLocationCommand request, CancellationToken cancellationToken)
    {
        var location = await repository.Locations
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
            ?? throw new KeyNotFoundException("Nie znaleziono podanej lokacji!");

        location.Update(
            request.Options.Name,
            request.Options.Address,
            request.Options.Longitude,
            request.Options.Latitude
        );

        await repository.SaveChangesAsync(cancellationToken);

        return new ResponseWrapper<Guid>() { Data = location.Id };
    }
}
