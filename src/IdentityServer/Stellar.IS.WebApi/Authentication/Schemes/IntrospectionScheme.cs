using Microsoft.AspNetCore.Authentication;

namespace Stellar.IS.WebApi.Authentication.Schemes;

public static class IntrospectionScheme
{
    public const string Name = "Introspection";

    public static AuthenticationBuilder AddStellarIntrospection(this AuthenticationBuilder builder)
    {
        builder.AddOAuth2Introspection(Name, options =>
        {
            options.Authority = "http://localhost:5000";
            options.ClientId = "TestApi";
            options.ClientSecret = "TestSecret";
            options.SaveToken = true;
        });

        return builder;
    }
}