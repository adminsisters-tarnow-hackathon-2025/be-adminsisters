using be_adminsisters.Common.Interfaces;
using be_adminsisters.Common.Models;
using be_adminsisters.UseCases.Achievements.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace be_adminsisters.UseCases.Achievements.Queries.GetAchievements;

public class GetAchievementsHandler(IRepository repository) : IRequestHandler<GetAchievementsQuery, ResponseWrapper<IEnumerable<AchievementDto>>>
{
    public async Task<ResponseWrapper<IEnumerable<AchievementDto>>> Handle(GetAchievementsQuery request, CancellationToken cancellationToken)
    {
        var achievements = await repository.Achievements
            .Select(x => new AchievementDto(x))
            .ToListAsync(cancellationToken);

        return new ResponseWrapper<IEnumerable<AchievementDto>> { Data = achievements };
        
    }
}