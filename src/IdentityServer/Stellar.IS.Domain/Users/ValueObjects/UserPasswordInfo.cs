using ErrorOr;

using Stellar.Core.DomainLayer.ValueObjects;

using Throw;

namespace Stellar.IS.Domain.Users.ValueObjects;

public sealed record UserPasswordInfo : ValueObject
{
    private UserPasswordInfo(string hash, byte[] salt)
    {
        Hash = hash.ThrowIfNull().IfEmpty();
        Salt = salt.ThrowIfNull().IfEmpty();
    }

    public static ErrorOr<UserPasswordInfo> Create(string hash, byte[] salt)
    {
        return new UserPasswordInfo(hash, salt);
    }

    public string Hash { get; private set; }
    public byte[] Salt { get; private set; }
}