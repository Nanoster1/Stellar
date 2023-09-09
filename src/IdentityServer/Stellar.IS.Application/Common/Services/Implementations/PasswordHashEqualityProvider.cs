using Stellar.IS.Application.Common.Services.Interfaces;

namespace Stellar.IS.Application.Common.Services.Implementations;

public class PasswordHashEqualityProvider : IPasswordHashEqualityProvider
{
    public bool HashesAreEqual(string hash1, string hash2)
    {
        return string.Equals(hash1, hash2, StringComparison.Ordinal);
    }
}
