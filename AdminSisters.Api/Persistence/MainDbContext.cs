using AdminSisters.Api.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace AdminSisters.Api.Persistence;

public class MainDbContext : DbContext, IRepository
{
    public MainDbContext(DbContextOptions<MainDbContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}
