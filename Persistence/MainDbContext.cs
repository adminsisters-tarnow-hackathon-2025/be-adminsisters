using System.Reflection;
using be_adminsisters.Common.Interfaces;
using be_adminsisters.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace be_adminsisters.Persistence;

public class MainDbContext(DbContextOptions<MainDbContext> options) : DbContext(options), IRepository
{
    public DbSet<Location> Locations => Set<Location>();
    public DbSet<Event> Events => Set<Event>();
    public DbSet<User> Users => Set<User>();
    public DbSet<Achievement> Achievements => Set<Achievement>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}
