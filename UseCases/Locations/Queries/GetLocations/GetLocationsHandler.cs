using be_adminsisters.Common.Interfaces;
using be_adminsisters.Common.Models;
using be_adminsisters.UseCases.Locations.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace be_adminsisters.UseCases.Locations.Queries.GetLocations
{
    public class GetLocationsHandler(IRepository repository) : IRequestHandler<GetLocationsQuery, ResponseWrapper<IEnumerable<LocationDto>>>
    {
        public async Task<ResponseWrapper<IEnumerable<LocationDto>>> Handle(GetLocationsQuery request, CancellationToken cancellationToken)
        {
            var users = await repository.Locations.ToListAsync(cancellationToken);
            return new ResponseWrapper<IEnumerable<LocationDto>> { Data = users.Select(x => new LocationDto(x)) };
        }
    }
}
