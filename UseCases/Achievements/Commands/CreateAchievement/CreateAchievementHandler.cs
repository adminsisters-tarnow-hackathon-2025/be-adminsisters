using be_adminsisters.Common.Interfaces;
using be_adminsisters.Common.Models;
using be_adminsisters.Persistence.Entities;
using MediatR;

namespace be_adminsisters.UseCases.Achievements.Commands.CreateAchievement;

public class CreateAchievementHandler(IRepository repository)
    : IRequestHandler<CreateAchievementCommand, ResponseWrapper<Guid>>
{
    public async Task<ResponseWrapper<Guid>> Handle(CreateAchievementCommand request, CancellationToken cancellationToken)
    {
        var achievement = Achievement.Create(request.Name, request.Description, request.Points, request.Goal);
        await repository.Achievements.AddAsync(achievement, cancellationToken);
        await repository.SaveChangesAsync(cancellationToken);

        return new ResponseWrapper<Guid> { Data = achievement.Id };
    }
}