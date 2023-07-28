using NSpecifications;

using Stellar.IS.Domain.Users;
using Stellar.IS.Domain.Users.ValueObjects;

namespace Stellar.IS.Application.Common.Specifications;

public static class UserSpecs
{
    public static ASpec<User> EmailEquals(UserEmail email)
    {
        return new Spec<User>(user => user.Email == email);
    }
}