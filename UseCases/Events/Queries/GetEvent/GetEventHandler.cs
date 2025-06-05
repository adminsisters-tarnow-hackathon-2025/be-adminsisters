using be_adminsisters.Common.Interfaces;
using be_adminsisters.Common.Models;
using be_adminsisters.UseCases.Events.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace be_adminsisters.UseCases.Events.Queries.GetEvent;

public class GetEventHandler(IRepository repository) : IRequestHandler<GetEventQuery, ResponseWrapper<EventDto>>
{
    public async Task<ResponseWrapper<EventDto>> Handle(GetEventQuery request, CancellationToken cancellationToken)
    {
        var eventEntity = await repository.Events
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
            ?? throw new KeyNotFoundException($"Nie znaleziono podanego wydarzenia!");
        
        return new ResponseWrapper<EventDto>() { Data = new EventDto(eventEntity) };
    }
}