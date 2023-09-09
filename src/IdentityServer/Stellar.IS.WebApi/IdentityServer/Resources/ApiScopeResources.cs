using Duende.IdentityServer.Models;

namespace Stellar.IS.WebApi.IdentityServer.Resources;

public static partial class StellarResources
{
    public static ApiScope[] ApiScopes => new ApiScope[]
    {
        new ApiScope("StellarApi.MainScope", "Stellar Platform")
    };
}