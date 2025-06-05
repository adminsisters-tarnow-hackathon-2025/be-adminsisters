using be_adminsisters.Common.Models;
using be_adminsisters.UseCases.Achievements.Dtos;
using MediatR;

namespace be_adminsisters.UseCases.Achievements.Queries.GetAchievements;

public record GetAchievementsQuery() : IRequest<ResponseWrapper<IEnumerable<AchievementDto>>>;