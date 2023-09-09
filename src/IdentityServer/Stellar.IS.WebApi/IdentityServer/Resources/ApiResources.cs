using Duende.IdentityServer.Models;

namespace Stellar.IS.WebApi.IdentityServer.Resources;

public static partial class StellarResources
{
    public static ApiResource[] ApiResources => new[]
    {
        new ApiResource()
        {
            Name = "StellarApi",
            DisplayName = "Stellar main api",
            Description = "Stellar main api",
            Enabled = true,
            Scopes = { "StellarApi.MainScope" },
            ApiSecrets = new[] { new Secret("StellarApiSecret".Sha256()) },
            UserClaims = Array.Empty<string>()
        }
    };
}