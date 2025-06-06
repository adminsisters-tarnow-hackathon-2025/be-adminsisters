using be_adminsisters.Common.Models;
using be_adminsisters.UseCases.Events.Dtos;
using be_adminsisters.UseCases.Locations.Dtos;
using MediatR;

namespace be_adminsisters.UseCases.Locations.Queries.GetLocationsWithEvents;

public record GetLocationsWithEventsQuery() : IRequest<ResponseWrapper<IEnumerable<LocationWithEventDto>>>;