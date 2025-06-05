namespace be_adminsisters.Persistence.Entities;

public class UserAchievement
{
    public Guid UserId { get; init; }
    public User? User { get; init; }
    public Guid AchievementId { get; init; }
    public Achievement? Achievement { get; init; }
    
    private UserAchievement()
    {
    }
    public static UserAchievement Create(Guid userId, Guid achievementId)
    {
        return new UserAchievement
        {
            UserId = userId,
            AchievementId = achievementId
        };
    }
    
}