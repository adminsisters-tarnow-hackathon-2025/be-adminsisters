namespace AdminSisters.Api.Common.Interfaces;

public interface IRepository
{
    int SaveChanges();
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
