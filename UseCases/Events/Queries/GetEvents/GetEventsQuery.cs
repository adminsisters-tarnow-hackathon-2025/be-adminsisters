using be_adminsisters.Common.Models;
using be_adminsisters.UseCases.Events.Dtos;
using MediatR;

namespace be_adminsisters.UseCases.Events.Queries.GetEvents;

public record GetEventsQuery(): IRequest<ResponseWrapper<IEnumerable<EventDto>>>;
