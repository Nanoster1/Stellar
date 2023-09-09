using Duende.IdentityServer.Models;

using ISClient = Duende.IdentityServer.Models.Client;

namespace Stellar.IS.WebApi.IdentityServer.Resources;

public static partial class StellarResources
{
    public static ISClient[] Clients => new[]
    {
        new ISClient()
        {
            ClientId = "StellarApiSwagger",
            ClientSecrets = { new Secret("StellarApiSwaggerSecret".Sha256()) },
            AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
            AccessTokenType = AccessTokenType.Reference,
            AllowedScopes = { "StellarApi.MainScope" }
        }
    };
}