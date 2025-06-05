using AdminSisters.Api.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using AdminSisters.Api.Persistence.Entities;

namespace AdminSisters.Api.Persistence;

public class MainDbContext(DbContextOptions<MainDbContext> options) : DbContext(options), IRepository
{
    public DbSet<User> Users => Set<User>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}
