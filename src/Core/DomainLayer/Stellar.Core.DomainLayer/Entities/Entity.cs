using Stellar.Core.DomainLayer.Abstractions.Entities;

namespace Stellar.Core.DomainLayer.Entities;

public abstract class Entity<TId> : IEntity<TId>
    where TId : IEquatable<TId>
{
    private int? _requestedHashCode;

    protected Entity() { }

    public TId Id { get; private set; } = default!;

    public bool IsTransient() => Id?.Equals(default) ?? false;

    public override bool Equals(object? obj)
    {
        return Equals(obj as IEntity<TId>);
    }

    public bool Equals(IEntity<TId>? other)
    {
        return ReferenceEquals(this, other)
            || (other is not null && (Id?.Equals(other.Id) ?? false));
    }

    public override int GetHashCode()
    {
        return IsTransient()
            ? base.GetHashCode()
            : _requestedHashCode ??= Id!.GetHashCode() ^ 31;
    }

    public static bool operator ==(Entity<TId>? left, IEntity<TId>? right)
    {
        return left?.Equals(right) is true;
    }

    public static bool operator !=(Entity<TId>? left, IEntity<TId>? right)
    {
        return left?.Equals(right) is not true;
    }
}