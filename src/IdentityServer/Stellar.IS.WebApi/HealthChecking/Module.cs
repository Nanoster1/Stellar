using HealthChecks.UI.Client;

using Microsoft.AspNetCore.Diagnostics.HealthChecks;

using Stellar.IS.Contracts.Routes.WebApi;

namespace Stellar.IS.WebApi.HealthChecking;

public static class Module
{
    public static IApplicationBuilder UseStellarISHealthChecks(this IApplicationBuilder app)
    {
        app.UseHealthChecks(WebApiRoutes.HealthCheck, new HealthCheckOptions()
        {
            ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
        });

        return app;
    }
}