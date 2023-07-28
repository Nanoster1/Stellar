using Stellar.IS.WebApi.Logging.Configurations;

namespace Stellar.IS.WebApi.Logging;

public static class Module
{
    public static ILoggingBuilder AddStellarISLogging(
        this ILoggingBuilder builder,
        IConfiguration configuration)
    {
        builder.ClearProviders();
        builder.AddSerilogLogging(configuration);
        return builder;
    }
}