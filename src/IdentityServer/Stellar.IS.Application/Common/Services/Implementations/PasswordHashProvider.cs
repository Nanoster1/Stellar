using System.Security.Cryptography;

using Stellar.IS.Application.Common.Services.Interfaces;

namespace Stellar.IS.Application.Common.Services.Implementations;

public class PasswordHashProvider : IPasswordHashProvider
{
    private const int HashSize = 50;
    private const int Iterations = 256;

    public HashedPassword Hash(string password, byte[] salt)
    {
        var hash = new byte[HashSize];
        Rfc2898DeriveBytes.Pbkdf2(
            password,
            salt,
            destination: hash,
            iterations: Iterations,
            hashAlgorithm: HashAlgorithmName.SHA512);

        return new HashedPassword(Convert.ToBase64String(hash), salt);
    }

    public HashedPassword Hash(string password)
    {
        var hash = new byte[HashSize];
        var salt = GenerateRandomSalt();
        Rfc2898DeriveBytes.Pbkdf2(
            password,
            salt,
            destination: hash,
            iterations: Iterations,
            hashAlgorithm: HashAlgorithmName.SHA512);
        return new HashedPassword(Convert.ToBase64String(hash), salt);
    }

    private static byte[] GenerateRandomSalt()
    {
        using var rng = RandomNumberGenerator.Create();

        var randomBytes = new byte[1];
        rng.GetBytes(randomBytes);
        var saltSize = randomBytes[0];

        var salt = new byte[saltSize];
        rng.GetBytes(salt);

        return salt;
    }
}