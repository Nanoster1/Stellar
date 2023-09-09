using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Stellar.Core.RepositoryPattern.Abstractions;
using Stellar.IS.Application.Common.Repositories;
using Stellar.IS.Infrastructure.Persistence;
using Stellar.IS.Infrastructure.Persistence.Repositories;

namespace Stellar.IS.Infrastructure;

public static class Module
{
    public static IServiceCollection AddStellarISInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        AddRepositories(services, configuration);
        return services;
    }

    private static void AddRepositories(
        IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<StellarDbContext>(
            options => StellarDbContext.Configure(options, configuration));

        services.AddScoped<IUserRepository, UserRepository>();

        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}