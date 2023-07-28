using Stellar.Core.DomainLayer.ValueObjects;

using Throw;

namespace Stellar.IS.Domain.Users.ValueObjects;

public sealed record UserId : SimpleValueObject<UserId, Guid>
{
    [Obsolete(ObsoleteMessage, true)] public UserId() { }
}