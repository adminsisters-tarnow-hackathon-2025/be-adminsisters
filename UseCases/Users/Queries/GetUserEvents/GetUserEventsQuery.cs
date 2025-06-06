using be_adminsisters.Common.Models;
using be_adminsisters.UseCases.Events.Dtos;
using MediatR;

namespace be_adminsisters.UseCases.Users.Queries.GetUserEvents
{
    public record GetUserEventsQuery(Guid UserId) : IRequest<ResponseWrapper<IEnumerable<EventDto>>>;
}
