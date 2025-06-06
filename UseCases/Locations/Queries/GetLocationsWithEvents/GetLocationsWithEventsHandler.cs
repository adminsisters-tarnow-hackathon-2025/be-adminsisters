using be_adminsisters.Common.Interfaces;
using be_adminsisters.Common.Models;
using be_adminsisters.UseCases.Locations.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace be_adminsisters.UseCases.Locations.Queries.GetLocationsWithEvents;

public class GetLocationsWithEventsHandler(IRepository repository) : IRequestHandler<GetLocationsWithEventsQuery, ResponseWrapper<IEnumerable<LocationWithEventDto>>>
{
    public async Task<ResponseWrapper<IEnumerable<LocationWithEventDto>>> Handle(GetLocationsWithEventsQuery request, CancellationToken cancellationToken)
    {
        var locations = await repository.Locations
            .Include(x => x.Events)
            .Where(x => x.Events.Any())
            .ToListAsync(cancellationToken);

        return new ResponseWrapper<IEnumerable<LocationWithEventDto>>() { Data = locations.ConvertAll(x => new LocationWithEventDto(x))};
    }
}
