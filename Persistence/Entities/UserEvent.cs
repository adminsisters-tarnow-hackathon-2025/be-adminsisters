namespace be_adminsisters.Persistence.Entities;

public class UserEvent
{
    public Guid UserId { get; init; }
    public User? User { get; init; }
    public Guid EventId { get; init; }
    public Event? Event { get; init; }
}
