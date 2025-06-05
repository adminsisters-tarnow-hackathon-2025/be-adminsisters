using be_adminsisters.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace be_adminsisters.UseCases.Achievements.Commands.UpdateAchievement;

public class UpdateAchievementHandler(IRepository repository) : IRequestHandler<UpdateAchievementCommand>
{
    public async Task Handle(UpdateAchievementCommand request, CancellationToken cancellationToken)
    {
        var achievement = await repository.Achievements.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
                          ?? throw new KeyNotFoundException($"Nie znaleziono podanego osiągnięcia!");

        achievement.Name = request.Options.Name ?? achievement.Name;
        achievement.Description = request.Options.Description ?? achievement.Description;
        achievement.Goal = request.Options.Goal ?? achievement.Goal;
        achievement.Points = request.Options.Points ?? achievement.Points;

        repository.Achievements.Update(achievement);
        await repository.SaveChangesAsync(cancellationToken);
    }
}