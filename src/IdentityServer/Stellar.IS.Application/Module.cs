using System.Globalization;

using FluentValidation;

using MediatR;

using Microsoft.Extensions.DependencyInjection;

using Stellar.Core.ApplicationLayer.MediatR.Behaviors;
using Stellar.IS.Application.Common.Behaviors;
using Stellar.IS.Application.Common.Services.Implementations;
using Stellar.IS.Application.Common.Services.Interfaces;
using Stellar.IS.Domain;

namespace Stellar.IS.Application;

public static class Module
{
    public static IServiceCollection AddStellarISApplication(this IServiceCollection services)
    {
        CultureInfo.DefaultThreadCurrentCulture = DomainConfiguration.CultureInfo;
        AddFluentValidation(services);
        AddMediatR(services);
        AddServices(services);
        return services;
    }

    private static void AddMediatR(IServiceCollection services)
    {
        var handlersAssemblies = new[]
        {
            typeof(ValidationBehavior<,>).Assembly,
            typeof(Module).Assembly
        };

        services.AddMediatR(config => config.RegisterServicesFromAssemblies(handlersAssemblies));

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ExceptionBehavior<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
    }

    private static void AddFluentValidation(IServiceCollection services)
    {
        var assembly = typeof(Module).Assembly;
        services.AddValidatorsFromAssembly(assembly);
    }

    private static void AddServices(IServiceCollection services)
    {
        services.AddScoped<IPasswordHashProvider, PasswordHashProvider>();
        services.AddScoped<IPasswordHashEqualityProvider, PasswordHashEqualityProvider>();
    }
}