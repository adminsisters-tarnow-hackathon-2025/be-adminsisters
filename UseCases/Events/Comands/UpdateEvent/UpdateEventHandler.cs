using be_adminsisters.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace be_adminsisters.UseCases.Events.Comands.UpdateEvent;

public class UpdateEventHandler(IRepository repository) : IRequestHandler<UpdateEventCommand>
{
    public async Task Handle(UpdateEventCommand request, CancellationToken cancellationToken)
    {
        var eventEntity = await repository.Events.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
            ?? throw new KeyNotFoundException($"Nie znaleziono podanego wydarzenia!");;
        
        eventEntity.Name = request.Options.Name ?? eventEntity.Name;
        eventEntity.ShortDescription = request.Options.ShortDescription ?? eventEntity.ShortDescription;
        eventEntity.LongDescription = request.Options.LongDescription ?? eventEntity.LongDescription;
        eventEntity.Price = request.Options.Price ?? eventEntity.Price;
        eventEntity.CoinReward = request.Options.CoinReward ?? eventEntity.CoinReward;
        eventEntity.Type = request.Options.Type ?? eventEntity.Type;
        eventEntity.Tags = request.Options.Tags ?? eventEntity.Tags;
        eventEntity.DateFrom = request.Options.DateFrom ?? eventEntity.DateFrom;
        eventEntity.DateTo = request.Options.DateTo ?? eventEntity.DateTo;
        eventEntity.LocationId = request.Options.LocationId ?? eventEntity.LocationId;
        await repository.SaveChangesAsync(cancellationToken);
    }
}