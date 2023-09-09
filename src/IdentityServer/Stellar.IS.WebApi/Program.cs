using Duende.IdentityServer.Models;

using Hellang.Middleware.ProblemDetails;

using Microsoft.AspNetCore.Hosting.StaticWebAssets;

using Stellar.IS.Application;
using Stellar.IS.Contracts.Routes.WebApi;
using Stellar.IS.Infrastructure;
using Stellar.IS.WebApi.Configuration;
using Stellar.IS.WebApi.Environment;
using Stellar.IS.WebApi.HealthChecking;
using Stellar.IS.WebApi.IdentityServer;
using Stellar.IS.WebApi.Logging;
using Stellar.IS.WebApi.ProblemDetails;

var builder = WebApplication.CreateBuilder(args);

var environment = builder.Environment
    .AddStellarEnvironment();

var configuration = builder.Configuration
    .AddStellarISConfiguration();

var logging = builder.Logging
    .AddStellarISLogging(configuration);

var services = builder.Services;
{
    services.AddStellarISApplication();
    services.AddStellarISInfrastructure(configuration);
    services.AddStellarIdentityServer();
    services.AddStellarISProblemDetails();
    services.AddLocalApiAuthentication();
    services.AddHealthChecks();
    services.AddControllers();
    services.AddSwaggerGen();
    services.AddEndpointsApiExplorer();
}

var app = builder.Build();
{
    if (environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseProblemDetails();

    app.UseExceptionHandler(WebApiRoutes.Controllers.ErrorController);

    app.UseStaticFiles();

    app.UseRouting();

    app.UseStellarISHealthChecks();
    app.UseStellarIdentityServer();

    app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllers();
}

app.Run();
