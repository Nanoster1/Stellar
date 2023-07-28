using Stellar.Core.RepositoryPattern.EntityFrameworkCore;

namespace Stellar.IS.Infrastructure.Persistence;

public class UnitOfWork : EntityFrameworkUnitOfWork
{
    public UnitOfWork(StellarDbContext context) : base(context)
    {
    }
}