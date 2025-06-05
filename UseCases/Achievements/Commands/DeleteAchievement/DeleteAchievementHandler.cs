using be_adminsisters.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace be_adminsisters.UseCases.Achievements.Commands.DeleteAchievement;

public class DeleteAchievementHandler(IRepository repository) : IRequestHandler<DeleteAchievementCommand>
{
    public async Task Handle(DeleteAchievementCommand request, CancellationToken cancellationToken)
    {
        var achievement = await repository.Achievements.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
            ?? throw new KeyNotFoundException($"Nie znaleziono podanego osiągnięcia!");
        
        repository.Achievements.Remove(achievement);
        await repository.SaveChangesAsync(cancellationToken);
    }
}