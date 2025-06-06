using be_adminsisters.Common.Interfaces;
using be_adminsisters.Common.Models;
using be_adminsisters.UseCases.Events.Dtos;
using be_adminsisters.UseCases.Users.Queries.GetUsers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace be_adminsisters.UseCases.Users.Queries.GetUserEvents
{
    public class GetUserEventsHandler(IRepository repository) : IRequestHandler<GetUserEventsQuery, ResponseWrapper<IEnumerable<EventDto>>>
    {
        public async Task<ResponseWrapper<IEnumerable<EventDto>>> Handle(GetUserEventsQuery request, CancellationToken cancellationToken)
        {
            var user = await repository.Users
                .Include(x => x.UserEvents)!
                .ThenInclude(x => x.Event)
            .FirstOrDefaultAsync(u => u.Id == request.UserId, cancellationToken)
            ?? throw new KeyNotFoundException("Nie znaleziono podanego użytkownika!");

            var eventDtos = user.UserEvents!
                .Select(ue => new EventDto(ue.Event!))
                .ToList();

            return new ResponseWrapper<IEnumerable<EventDto>>
            {
                Data = eventDtos
            };
        }
    }
}
