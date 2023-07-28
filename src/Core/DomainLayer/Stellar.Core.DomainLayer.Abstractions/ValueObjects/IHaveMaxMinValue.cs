namespace Stellar.Core.DomainLayer.Abstractions.ValueObjects;

public interface IHaveMaxMinValue<TSelf>
    where TSelf : IHaveMaxMinValue<TSelf>, IComparable<TSelf>
{
    abstract static TSelf? MaxValue { get; }
    abstract static TSelf? MinValue { get; }
}