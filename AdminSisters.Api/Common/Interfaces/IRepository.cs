using AdminSisters.Api.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace AdminSisters.Api.Common.Interfaces;

public interface IRepository
{
    public DbSet<User> Users  { get; }
    int SaveChanges();
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
