using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

using Stellar.IS.Infrastructure.Persistence;

namespace GigaChat.Migrations;

public class Factory : IDesignTimeDbContextFactory<StellarDbContext>
{
    public StellarDbContext CreateDbContext(string[] args)
    {
        var configurationBuilder = new ConfigurationBuilder()
            .AddYamlFile("appsettings.yaml")
            .AddEnvironmentVariables()
            .AddUserSecrets<Factory>();

        var configuration = configurationBuilder.Build();
        var optionsBuilder = new DbContextOptionsBuilder<StellarDbContext>();
        StellarDbContext.Configure(optionsBuilder, configuration, typeof(Factory).Assembly);

        return new StellarDbContext(optionsBuilder.Options);
    }
}