using be_adminsisters.Common.Interfaces;
using be_adminsisters.Common.Models;
using be_adminsisters.Persistence.Entities;
using MediatR;

namespace be_adminsisters.UseCases.Events.Comands.CreateEvent;

public class CreateEventHandler(IRepository repository) : IRequestHandler<CreateEventCommand, ResponseWrapper<Guid>>
{
    public async Task<ResponseWrapper<Guid>> Handle(CreateEventCommand request, CancellationToken cancellationToken)
    {
        try
        {
            // Validate required fields
            if (string.IsNullOrEmpty(request.Name))
                throw new ArgumentException("Name is required");
            
            if (request.LocationId == Guid.Empty)
                throw new ArgumentException("Valid LocationId is required");

            var eventEntity = Event.Create(
                request.Name,
                request.ShortDescription,
                request.LongDescription,
                request.Type,
                request.Price,
                request.CoinReward,
                request.Tags,
                request.DateFrom.Kind == DateTimeKind.Unspecified ? DateTime.SpecifyKind(request.DateFrom, DateTimeKind.Utc) : request.DateFrom.ToUniversalTime(),
                request.DateTo.Kind == DateTimeKind.Unspecified ? DateTime.SpecifyKind(request.DateTo, DateTimeKind.Utc) : request.DateTo.ToUniversalTime(),
                request.Image,
                request.LocationId
            );
            
            await repository.Events.AddAsync(eventEntity, cancellationToken);
            await repository.SaveChangesAsync(cancellationToken);
            
            return new ResponseWrapper<Guid> { Data = eventEntity.Id };
        }
        catch (Exception ex)
        {
            return new ResponseWrapper<Guid> 
            { 
                Data = Guid.Empty,
            };
        }
    }
}