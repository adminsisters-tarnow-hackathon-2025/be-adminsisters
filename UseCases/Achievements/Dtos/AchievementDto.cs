using be_adminsisters.Persistence.Entities;

namespace be_adminsisters.UseCases.Achievements.Dtos;

public sealed class AchievementDto(Achievement achievement)
{
    public string Name { get; } = achievement.Name;
    public string Description { get; } = achievement.Description;
    public int Points { get; } = achievement.Points;
    public int Goal { get; } = achievement.Goal;
}