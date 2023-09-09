namespace Stellar.IS.Application.Common.Services.Interfaces;

public interface IPasswordHashEqualityProvider
{
    bool HashesAreEqual(string hash1, string hash2);
}
