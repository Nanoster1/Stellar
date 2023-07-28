using System.Reflection;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using SmartEnum.EFCore;

using Stellar.Core.DomainLayer.EntityFrameworkCore.Extensions;
using Stellar.IS.Domain;
using Stellar.IS.Domain.Users;

using Throw;

namespace Stellar.IS.Infrastructure.Persistence;

public class StellarDbContext : DbContext
{
    public const string ConnectionStringName = "StellarDb";

    public StellarDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ThrowIfNull();
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(StellarDbContext).Assembly);
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.ConfigureSmartEnum();
        configurationBuilder.ConfigureSimpleValueObjects();
    }

    public static void Configure(
        DbContextOptionsBuilder optionsBuilder,
        IConfiguration configuration,
        Assembly? migrationAssembly = null)
    {
        optionsBuilder.ThrowIfNull();
        configuration.ThrowIfNull();

        var connectionString = configuration.GetConnectionString(ConnectionStringName)
            .ThrowIfNull()
            .IfEmpty();

        var builder = optionsBuilder.UseSqlite(connectionString, options =>
        {
            if (migrationAssembly is not null)
            {
                options.MigrationsAssembly(migrationAssembly.FullName);
            }
        });

        builder.UseSnakeCaseNamingConvention(DomainConfiguration.CultureInfo);
    }
}