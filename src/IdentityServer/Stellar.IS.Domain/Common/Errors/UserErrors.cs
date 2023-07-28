using ErrorOr;

using Stellar.IS.Domain.Users.ValueObjects;

namespace Stellar.IS.Domain.Common.Errors;

public static class UserErrors
{
    public static Error UsernameLengthOutOfRange => Error.Validation();
    public static Error UsernameInvalid => Error.Validation();
    public static Error UserWithIdNotFound(UserId id) => Error.NotFound();
    public static Error UserWithEmailNotFound(UserEmail email) => Error.NotFound();
    public static Error EmailInvalid => Error.Validation();
    public static Error UserWithSameEmailAlreadyExists => Error.Conflict();
}