using System.Runtime.CompilerServices;
using System.Security.Claims;

using Stellar.IS.Domain.Users;
using Stellar.IS.Domain.Users.Enums;

namespace Stellar.IS.Application.Users.Models;

public record UserModel(Guid Id, string Username, bool IsActive)
{
    internal static UserModel CreateFromDomainUser(User user)
    {
        return new UserModel(
            Id: user.Id,
            Username: user.Username,
            IsActive: user.ActivityStatus == UserActivityStatus.Active);
    }
}