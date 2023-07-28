using System.Text.RegularExpressions;

using ErrorOr;

using Stellar.Core.DomainLayer.ValueObjects;
using Stellar.IS.Domain.Common.DomainConstants;
using Stellar.IS.Domain.Common.Errors;

namespace Stellar.IS.Domain.Users.ValueObjects;

public partial record UserEmail : SimpleValueObject<UserEmail, string>
{
    public static Regex Pattern { get; } = GetPattern();

    [Obsolete(ObsoleteMessage, true)] public UserEmail() { }

    protected override ErrorOr<Success> Validate(string value)
    {
        var errors = new List<Error>();

        if (!Pattern.IsMatch(value))
            errors.Add(UserErrors.EmailInvalid);

        return errors.Count == 0 ? Result.Success : errors;
    }

    [GeneratedRegex(
        "^[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$",
        RegexConstants.Options, RegexConstants.Timeout)]
    private static partial Regex GetPattern();
}