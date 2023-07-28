using Serilog;

namespace Stellar.IS.WebApi.Logging.Configurations;

public static class SerilogLoggingConfig
{
    public static ILoggingBuilder AddSerilogLogging(
        this ILoggingBuilder builder,
        IConfiguration configuration)
    {
        var logger = new LoggerConfiguration()
            .ReadFrom.Configuration(configuration)
            .CreateLogger();

        builder.AddSerilog(logger, true);

        return builder;
    }
}