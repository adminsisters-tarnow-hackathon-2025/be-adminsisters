using be_adminsisters.Common.Models;
using be_adminsisters.UseCases.Achievements.Dtos;
using MediatR;

namespace be_adminsisters.UseCases.Achievements.Queries.GetAchievement;

public record GetAchievementQuery(Guid Id) : IRequest<ResponseWrapper<AchievementDto>>;