using System.Runtime.CompilerServices;

using Microsoft.EntityFrameworkCore;

using NSpecifications;

using Stellar.Core.DomainLayer.Abstractions.Entities;
using Stellar.Core.RepositoryPattern.Abstractions;

namespace Stellar.Core.RepositoryPattern.EntityFrameworkCore;

public abstract class EntityFrameworkRepository<TEntity, TId> : IRepository<TEntity, TId>
    where TEntity : class, IEntity<TId>
    where TId : IEquatable<TId>
{
    protected readonly DbContext _context;
    protected readonly DbSet<TEntity> _set;

    protected EntityFrameworkRepository(DbContext context)
    {
        _context = context;
        _set = context.Set<TEntity>();
    }

    public virtual async Task<TEntity?> FindOneAsync(
        TId id,
        CancellationToken cancellationToken = default)
    {
        return await _set.AsNoTracking()
           .Where(x => x.Id.Equals(id))
           .FirstOrDefaultAsync(cancellationToken);
    }

    public virtual Task<TEntity?> FindOneAsync(
        ISpecification<TEntity>? spec = null,
        CancellationToken cancellationToken = default)
    {
        spec ??= Spec.Any<TEntity>();
        return _set.AsNoTracking()
            .Where(spec.Expression)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public virtual async IAsyncEnumerable<TEntity> FindManyAsync(
        ICollection<TId> ids,
        Range range = default,
        [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        var query = _set.AsNoTracking()
            .Where(x => ids.Contains(x.Id));

        if (!CheckRange(range))
        {
            throw new ArgumentOutOfRangeException(nameof(range));
        }

        if (!range.Equals(default) && !range.Equals(Range.All))
        {
            var recordsCount = await query.CountAsync(cancellationToken);
            (var offset, var length) = range.GetOffsetAndLength(recordsCount);
            query = query.Skip(offset).Take(length);
        }

        await foreach (var entity in query.AsAsyncEnumerable().WithCancellation(cancellationToken))
        {
            yield return entity;
        }
    }

    public virtual async IAsyncEnumerable<TEntity> FindManyAsync(
        ISpecification<TEntity>? spec = null,
        Range range = default,
        [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        spec ??= Spec.Any<TEntity>();

        var query = _set.AsNoTracking()
            .Where(spec.Expression);

        if (!CheckRange(range))
        {
            throw new ArgumentOutOfRangeException(nameof(range));
        }

        if (!range.Equals(default) && !range.Equals(Range.All))
        {
            var recordsCount = await query.CountAsync(cancellationToken);
            (var offset, var length) = range.GetOffsetAndLength(recordsCount);
            query = query.Skip(offset).Take(length);
        }

        await foreach (var entity in query.AsAsyncEnumerable().WithCancellation(cancellationToken))
        {
            yield return entity;
        }
    }

    public virtual async Task<bool> ExistsAsync(
        ICollection<TId> ids,
        CancellationToken cancellationToken = default)
    {
        return await _set
            .AnyAsync(x => ids.Contains(x.Id), cancellationToken);
    }

    public virtual async Task<bool> ExistsAsync(
        ISpecification<TEntity>? spec = null,
        CancellationToken cancellationToken = default)
    {
        spec ??= Spec.Any<TEntity>();
        return await _set
            .AnyAsync(spec.Expression, cancellationToken);
    }

    public virtual Task InsertAsync(
        TEntity entity,
        CancellationToken cancellationToken = default)
    {
        _set.Add(entity);
        return Task.CompletedTask;
    }

    public virtual Task UpdateAsync(
        TEntity entity,
        CancellationToken cancellationToken = default)
    {
        _set.Update(entity);
        return Task.CompletedTask;
    }

    public virtual Task DeleteAsync(
        TEntity entity,
        CancellationToken cancellationToken = default)
    {
        _set.Remove(entity);
        return Task.CompletedTask;
    }

    public virtual async Task<int> CountAsync(
        ISpecification<TEntity>? spec = null,
        CancellationToken cancellationToken = default)
    {
        spec ??= Spec.Any<TEntity>();
        return await _set.CountAsync(spec.Expression, cancellationToken);
    }

    protected bool CheckRange(Range range)
    {
        return range.Start.Value <= range.End.Value;
    }
}