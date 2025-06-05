using be_adminsisters.Common.Models;
using be_adminsisters.UseCases.Locations.Dtos;
using MediatR;

namespace be_adminsisters.UseCases.Locations.Queries.GetLocations;

public record GetLocationsQuery() : IRequest<ResponseWrapper<IEnumerable<LocationDto>>>;
