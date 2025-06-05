using AdminSisters.Api.Common.Interfaces;
using AdminSisters.Api.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace AdminSisters.Api.Persistence;

public class MainDbContext : DbContext, IRepository
{
    public MainDbContext(DbContextOptions<MainDbContext> options) : base(options)
    {
    }
    public DbSet<Location> Locations { get; set; }
    public DbSet<Event> Events { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}
