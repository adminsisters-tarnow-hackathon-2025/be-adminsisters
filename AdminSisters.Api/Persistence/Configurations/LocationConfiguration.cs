using AdminSisters.Api.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdminSisters.Api.Persistence.Configurations;

public class LocationConfiguration : IEntityTypeConfiguration<Location>
{
    public void Configure(EntityTypeBuilder<Location> builder)
    {
        builder.HasKey(x => x.Id);

        builder
            .HasMany(x => x.Events)
            .WithOne(x => x.Location)
            .HasForeignKey(x => x.LocationId);
    }
}
