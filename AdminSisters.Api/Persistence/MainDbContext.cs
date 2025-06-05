using AdminSisters.Api.Common.Interfaces;
using AdminSisters.Api.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace AdminSisters.Api.Persistence;

public class MainDbContext(DbContextOptions<MainDbContext> options) : DbContext(options), IRepository
{
    public DbSet<Location> Locations => Set<Location>();
    public DbSet<Event> Events => Set<Event>();
    public DbSet<User> Users => Set<User>();
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}
