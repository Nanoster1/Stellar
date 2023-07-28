namespace Stellar.Core.DomainLayer.Abstractions.Entities;

public interface IEntity<TId> : IEquatable<IEntity<TId>>
    where TId : IEquatable<TId>
{
    TId Id { get; }
}