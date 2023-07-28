using ErrorOr;

using Stellar.Core.DomainLayer.Abstractions.Aggregates;
using Stellar.Core.DomainLayer.Entities;

namespace Stellar.Core.DomainLayer.Aggregates;

public abstract class AggregateRoot<TId> : Entity<TId>, IAggregateRoot<TId>
    where TId : IEquatable<TId>
{
    protected AggregateRoot() { }

    public abstract ErrorOr<Success> Validate();
}