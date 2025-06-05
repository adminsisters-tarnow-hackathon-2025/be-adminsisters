using be_adminsisters.Common.Models;
using MediatR;

namespace be_adminsisters.UseCases.Achievements.Commands.CreateAchievement;

public record CreateAchievementCommand(string Name, string Description, int Points, int Goal) : IRequest<ResponseWrapper<Guid>>;