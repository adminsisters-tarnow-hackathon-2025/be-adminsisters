using MediatR;

namespace be_adminsisters.UseCases.Achievements.Commands.UpdateAchievement;
public sealed record UpdateAchievementOptions(string? Name, string? Description, int? Points, int? Goal);
public sealed record UpdateAchievementCommand(Guid Id, UpdateAchievementOptions Options) : IRequest;