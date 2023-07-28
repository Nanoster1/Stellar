using System.Text.RegularExpressions;

using ErrorOr;

using Stellar.Core.DomainLayer.ValueObjects;
using Stellar.IS.Domain.Common.DomainConstants;
using Stellar.IS.Domain.Common.Errors;

namespace Stellar.IS.Domain.Users.ValueObjects;

public sealed partial record Username : SimpleValueObject<Username, string>
{
    public const int MaxLength = 128;
    public const int MinLength = 3;
    public static Regex Pattern { get; } = GetPattern();

    [Obsolete(ObsoleteMessage, true)] public Username() { }

    protected override ErrorOr<Success> Validate(string value)
    {
        var errors = new List<Error>();

        if (value.Length > MaxLength || value.Length < MinLength)
            errors.Add(UserErrors.UsernameLengthOutOfRange);

        if (Pattern.IsMatch(value))
            errors.Add(UserErrors.UsernameInvalid);

        return errors.Count == 0 ? Result.Success : errors;
    }

    [GeneratedRegex(".*", RegexConstants.Options, RegexConstants.Timeout)]
    private static partial Regex GetPattern();

}