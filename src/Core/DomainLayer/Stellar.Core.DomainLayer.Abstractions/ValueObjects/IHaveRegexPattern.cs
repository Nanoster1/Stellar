using System.Text.RegularExpressions;

namespace Stellar.Core.DomainLayer.Abstractions.ValueObjects;

public interface IHaveRegexPattern
{
    abstract static Regex Pattern { get; }
}