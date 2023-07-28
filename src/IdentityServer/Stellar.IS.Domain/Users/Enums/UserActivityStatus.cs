using Ardalis.SmartEnum;

namespace Stellar.IS.Domain.Users.Enums;

public sealed class UserActivityStatus : SmartEnum<UserActivityStatus>
{
    public static readonly UserActivityStatus Active = new(nameof(Active), 0);
    public static readonly UserActivityStatus Inactive = new(nameof(Inactive), 1);

    private UserActivityStatus(string name, int value) : base(name, value)
    {
    }
}