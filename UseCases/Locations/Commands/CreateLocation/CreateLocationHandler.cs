using be_adminsisters.Common.Interfaces;
using be_adminsisters.Common.Models;
using be_adminsisters.Persistence.Entities;
using MediatR;

namespace be_adminsisters.UseCases.Locations.Commands.CreateLocation;

public class CreateUserHandler(IRepository repository) : IRequestHandler<CreateLocationCommand, ResponseWrapper<Guid>>
{
    public async Task<ResponseWrapper<Guid>> Handle(CreateLocationCommand request, CancellationToken cancellationToken)
    {
        var location = Location.Create(
            request.Name,
            request.Address,
            request.Longitude,
            request.Latitude
        );

        await repository.Locations.AddAsync(location, cancellationToken);
        await repository.SaveChangesAsync(cancellationToken);

        return new ResponseWrapper<Guid>() { Data = location.Id };
    }
}
