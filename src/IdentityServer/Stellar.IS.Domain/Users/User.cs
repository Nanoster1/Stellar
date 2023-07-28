using ErrorOr;

using Stellar.Core.DomainLayer.Aggregates;
using Stellar.IS.Domain.Users.Enums;
using Stellar.IS.Domain.Users.ValueObjects;

using Throw;

namespace Stellar.IS.Domain.Users;

public sealed class User : AggregateRoot<UserId>
{
    private User() { }

    private User(
        Username username,
        UserEmail email,
        UserPasswordInfo passwordInfo,
        UserActivityStatus activityStatus)
    {
        Username = username.ThrowIfNull();
        Email = email.ThrowIfNull();
        PasswordInfo = passwordInfo.ThrowIfNull();
        ActivityStatus = activityStatus.ThrowIfNull();
    }

    public static ErrorOr<User> Create(
        Username username,
        UserEmail email,
        UserPasswordInfo passwordInfo,
        UserActivityStatus activityStatus)
    {
        var instance = new User(username, email, passwordInfo, activityStatus);
        var validationsResult = instance.Validate();
        return validationsResult.IsError ? validationsResult.Errors : instance;
    }

    public override ErrorOr<Success> Validate()
    {
        return Result.Success;
    }

    public Username Username { get; private set; } = null!;
    public UserEmail Email { get; private set; } = null!;
    public UserPasswordInfo PasswordInfo { get; private set; } = null!;
    public UserActivityStatus ActivityStatus { get; private set; } = null!;
}