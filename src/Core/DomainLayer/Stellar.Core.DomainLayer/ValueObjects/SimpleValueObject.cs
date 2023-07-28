using ErrorOr;

using Throw;

namespace Stellar.Core.DomainLayer.ValueObjects;

public abstract record SimpleValueObject<TSelf, TValue> : ValueObject
    where TSelf : SimpleValueObject<TSelf, TValue>, new()
    where TValue : notnull
{
    protected const string ObsoleteMessage = "Don't use that constructor";

    [Obsolete(ObsoleteMessage, true)] protected SimpleValueObject() { }

    protected SimpleValueObject(TValue value)
    {
        Value = value.ThrowIfNull();
    }

    public TValue Value { get; private set; } = default!;

    protected virtual ErrorOr<Success> Validate(TValue value) => Result.Success;

    public static ErrorOr<TSelf> Create(TValue value)
    {
        value.ThrowIfNull();
        var instance = new TSelf { Value = value };
        var result = instance.Validate(value);
        return result.IsError ? result.Errors : instance;
    }

    public static implicit operator TValue(SimpleValueObject<TSelf, TValue> value) => value.Value;
}