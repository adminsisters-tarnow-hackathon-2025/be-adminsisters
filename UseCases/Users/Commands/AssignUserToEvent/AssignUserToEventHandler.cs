using be_adminsisters.Common.Interfaces;
using be_adminsisters.Persistence.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace be_adminsisters.UseCases.Users.Commands.AssignUserToEvent;

public class AssignUserToEventHandler(IRepository repository) : IRequestHandler<AssignUserToEventCommand>
{
    public async Task Handle(AssignUserToEventCommand request, CancellationToken cancellationToken)
    {
        var user = await repository.Users
                       .Include(x => x.UserEvents)
            .FirstOrDefaultAsync(x => x.Id == request.UserId, cancellationToken)
            ?? throw new KeyNotFoundException("Nie znaleziono podanego użytkownika!");

        var @event = await repository.Events
            .FirstOrDefaultAsync(x => x.Id == request.EventId, cancellationToken)
            ?? throw new KeyNotFoundException("Nie znaleziono podanego wydarzenia!");

        if (user.UserEvents?.Any(ue => ue.EventId == request.EventId) == true)
        {
            throw new InvalidOperationException("Użytkownik jest już przypisany do tego wydarzenia!");
        }

        var userEvent = new UserEvent
        {
            UserId = user.Id,
            EventId = @event.Id
        };

        user.UserEvents!.Add(userEvent);

        await repository.SaveChangesAsync(cancellationToken);
    }
}
