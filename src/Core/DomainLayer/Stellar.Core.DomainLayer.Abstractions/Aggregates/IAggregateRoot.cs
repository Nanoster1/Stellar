using ErrorOr;

using Stellar.Core.DomainLayer.Abstractions.Entities;

namespace Stellar.Core.DomainLayer.Abstractions.Aggregates;

public interface IAggregateRoot<TId> : IEntity<TId>
    where TId : IEquatable<TId>
{
    ErrorOr<Success> Validate();
}