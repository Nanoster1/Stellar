using Duende.IdentityServer.Models;

namespace Stellar.IS.WebApi.IdentityServer.Resources;

public static partial class StellarResources
{
    public static IdentityResource[] IdentityResources => new IdentityResource[]
    {
        new IdentityResources.OpenId()
    };
}