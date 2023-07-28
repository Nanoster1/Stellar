namespace Stellar.IS.Application.Common.Services.Interfaces;

public record HashedPassword(string Hash, byte[] Salt);

public interface IPasswordHashProvider
{
    public HashedPassword Hash(string password, byte[] salt);
    public HashedPassword Hash(string password);
}