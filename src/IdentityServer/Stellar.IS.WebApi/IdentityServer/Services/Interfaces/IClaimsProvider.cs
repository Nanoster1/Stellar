using System.Security.Claims;

using Stellar.IS.Application.Users.Models;

namespace Stellar.IS.WebApi.IdentityServer.Services.Interfaces;

public interface IClaimsProvider
{
    IEnumerable<Claim> GetClaimsFromUserModel(UserModel userModel);
}