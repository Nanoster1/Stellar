using Microsoft.EntityFrameworkCore;

using Stellar.Core.RepositoryPattern.Abstractions;

namespace Stellar.Core.RepositoryPattern.EntityFrameworkCore;

public abstract class EntityFrameworkUnitOfWork : IUnitOfWork
{
    protected readonly DbContext _context;

    protected EntityFrameworkUnitOfWork(DbContext context)
    {
        _context = context;
    }

    public virtual async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }
}