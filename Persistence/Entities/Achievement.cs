namespace be_adminsisters.Persistence.Entities;
public class Achievement

{
    public Guid Id { get; init; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int Points { get; set; }
    public int Goal { get; set; }

    private Achievement()
    {
        
    }
    
    public static Achievement Create(string name, string description, int points, int goal)
    {
        return new Achievement
        {
            Id = Guid.NewGuid(),
            Name = name,
            Description = description,
            Points = points,
            Goal = goal
        };
    }
}