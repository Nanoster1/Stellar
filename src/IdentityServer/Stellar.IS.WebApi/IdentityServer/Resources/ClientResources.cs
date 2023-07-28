using Duende.IdentityServer.Models;

namespace Stellar.IS.WebApi.IdentityServer.Resources;

public static partial class StellarResources
{
    public static Client[] Clients => new Client[]
    {
        new Client()
        {
            ClientId = "TestClient",
            ClientSecrets = new List<Secret>() { new Secret("TestSecret".Sha256()) },
            AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,
            AllowedScopes = { "TestScope", "TestScope2" },
            AccessTokenType = AccessTokenType.Reference
        }
    };
}