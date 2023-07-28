namespace Stellar.Core.DomainLayer.Abstractions.ValueObjects;

public interface IHaveMaxMinLength
{
    int Length { get; }
    abstract static int? MaxLength { get; }
    abstract static int? MinLength { get; }
}