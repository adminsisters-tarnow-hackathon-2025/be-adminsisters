using be_adminsisters.Common.Interfaces;
using be_adminsisters.Common.Models;
using be_adminsisters.UseCases.Events.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace be_adminsisters.UseCases.Events.Queries.GetEvents;

public class GetEventsHandler(IRepository repository) : IRequestHandler<GetEventsQuery, ResponseWrapper<IEnumerable<EventDto>>>
{
    public async Task<ResponseWrapper<IEnumerable<EventDto>>> Handle(GetEventsQuery request, CancellationToken cancellationToken)
    {
        var eventEntity = await repository.Events.ToListAsync(cancellationToken);
        
        return new ResponseWrapper<IEnumerable<EventDto>>() { Data = eventEntity.ConvertAll(x => new EventDto(x)) };
    }
}