using System.Security.Claims;

using Stellar.IS.Application.Users.Models;
using Stellar.IS.Contracts.IdentityServer;
using Stellar.IS.WebApi.IdentityServer.Services.Interfaces;

namespace Stellar.IS.WebApi.IdentityServer.Services.Implementations;

public class ClaimsProvider : IClaimsProvider
{
    public IEnumerable<Claim> GetClaimsFromUserModel(UserModel userModel)
    {
        yield return new Claim(StellarClaimTypes.Sub, userModel.Id.ToString());
    }
}