using be_adminsisters.Common.Models;
using MediatR;

namespace be_adminsisters.UseCases.Achievements.Commands.DeleteAchievement;

public record DeleteAchievementCommand(Guid Id) : IRequest;