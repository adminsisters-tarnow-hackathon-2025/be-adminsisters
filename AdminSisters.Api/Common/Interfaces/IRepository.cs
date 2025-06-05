using AdminSisters.Api.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace AdminSisters.Api.Common.Interfaces;

public interface IRepository
{
    public DbSet<Location> Locations { get; }
    public DbSet<Event> Events { get; }
    public DbSet<User> Users  { get; }
    int SaveChanges();
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
