using Hellang.Middleware.ProblemDetails;

using ProblemDetailsOptions = Hellang.Middleware.ProblemDetails.ProblemDetailsOptions;

namespace Stellar.IS.WebApi.ProblemDetails;

public static class Module
{
    public static IServiceCollection AddStellarISProblemDetails(this IServiceCollection services)
    {
        services.AddProblemDetails((ProblemDetailsOptions options) => options.IncludeExceptionDetails = (_, _) => false);
        return services;
    }
}