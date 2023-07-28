using NSpecifications;

using Stellar.Core.DomainLayer.Abstractions.Entities;

namespace Stellar.Core.RepositoryPattern.Abstractions;

public interface IRepository<TEntity, TId>
    where TEntity : IEntity<TId>
    where TId : IEquatable<TId>
{
    Task<TEntity?> FindOneAsync(TId id, CancellationToken cancellationToken = default);
    Task<TEntity?> FindOneAsync(ISpecification<TEntity>? spec = null, CancellationToken cancellationToken = default);
    IAsyncEnumerable<TEntity> FindManyAsync(ICollection<TId> ids, Range range = default, CancellationToken cancellationToken = default);
    IAsyncEnumerable<TEntity> FindManyAsync(ISpecification<TEntity>? spec = null, Range range = default, CancellationToken cancellationToken = default);
    Task<bool> ExistsAsync(ICollection<TId> ids, CancellationToken cancellationToken = default);
    Task<bool> ExistsAsync(ISpecification<TEntity>? spec = null, CancellationToken cancellationToken = default);
    Task InsertAsync(TEntity entity, CancellationToken cancellationToken = default);
    Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
    Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default);
    Task<int> CountAsync(ISpecification<TEntity>? spec = null, CancellationToken cancellationToken = default);
}