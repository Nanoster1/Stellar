using Duende.IdentityServer.Models;

using Stellar.IS.WebApi.IdentityServer.Resources;
using Stellar.IS.WebApi.IdentityServer.Services.Implementations;
using Stellar.IS.WebApi.IdentityServer.Services.Interfaces;

namespace Stellar.IS.WebApi.IdentityServer;

public static class Module
{
    public static IServiceCollection AddStellarIdentityServer(this IServiceCollection services)
    {
        services.AddIdentityServer()
            .AddInMemoryApiResources(StellarResources.ApiResources)
            .AddInMemoryClients(StellarResources.Clients)
            .AddInMemoryIdentityResources(StellarResources.IdentityResources)
            .AddInMemoryApiScopes(StellarResources.ApiScopes)
            .AddProfileService<StellarProfileService>();

        services.AddScoped<IClaimsProvider, ClaimsProvider>();

        return services;
    }

    public static IApplicationBuilder UseStellarIdentityServer(this IApplicationBuilder app)
    {
        app.UseIdentityServer();
        return app;
    }
}