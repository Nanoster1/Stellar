using Stellar.IS.WebApi.Authentication.Schemes;

namespace Stellar.IS.WebApi.Authentication;

public static class Module
{
    public static IServiceCollection AddStellarAuthentication(this IServiceCollection services)
    {
        services.AddAuthentication(IntrospectionScheme.Name)
            .AddStellarIntrospection();

        return services;
    }
}