using Duende.IdentityServer.Models;

using Microsoft.IdentityModel.Tokens;

namespace Stellar.IS.WebApi.IdentityServer.Resources;

public static partial class StellarResources
{
    public static ApiResource[] ApiResources => new ApiResource[]
    {
        new ApiResource()
        {
            Name = "TestApi",
            DisplayName = "Test Api",
            Description = "Test Api",
            Enabled = true,
            Scopes = new[] { "TestScope" },
            ApiSecrets = new[] { new Secret("TestSecret".Sha256()) },
            UserClaims = new[] { "asd" }
        }
    };
}