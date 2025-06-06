using be_adminsisters.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace be_adminsisters.Persistence.Configurations;

public class UserEventConfiguration : IEntityTypeConfiguration<UserEvent>
{
    public void Configure(EntityTypeBuilder<UserEvent> builder)
    {
        builder.HasKey(ue => new { ue.UserId, ue.EventId });

        builder.HasOne(x => x.User)
            .WithMany()
            .HasForeignKey(x => x.UserId);
        
        builder.HasOne(x => x.Event)
            .WithMany()
            .HasForeignKey(x => x.EventId);
    }
}