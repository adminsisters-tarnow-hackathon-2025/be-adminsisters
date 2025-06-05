using be_adminsisters.Common.Interfaces;
using be_adminsisters.Common.Models;
using be_adminsisters.UseCases.Achievements.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace be_adminsisters.UseCases.Achievements.Queries.GetAchievement;

public class GetAchievementHandler(IRepository repository) : IRequestHandler<GetAchievementQuery, ResponseWrapper<AchievementDto>>
{
    public async Task<ResponseWrapper<AchievementDto>> Handle(GetAchievementQuery request, CancellationToken cancellationToken)
    {
        var achievement = await repository.Achievements.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
            ?? throw new KeyNotFoundException($"Nie znaleziono podanego osiągnięcia!");

        return new ResponseWrapper<AchievementDto>() { Data = new AchievementDto(achievement) };

    }
}