using System.Linq.Expressions;

using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

using Stellar.Core.DomainLayer.ValueObjects;

namespace Stellar.Core.DomainLayer.EntityFrameworkCore.Converters;

public class SimpleValueObjectConverter<TValueObject, TValue> : ValueConverter<TValueObject, TValue>
    where TValueObject : SimpleValueObject<TValueObject, TValue>, new()
    where TValue : notnull
{
    public SimpleValueObjectConverter() : base(
        v => v.Value,
        v => SimpleValueObject<TValueObject, TValue>.Create(v).Value)
    {
    }
}