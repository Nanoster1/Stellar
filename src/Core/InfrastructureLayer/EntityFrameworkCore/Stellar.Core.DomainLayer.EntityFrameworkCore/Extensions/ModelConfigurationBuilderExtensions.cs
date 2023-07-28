using Microsoft.EntityFrameworkCore;

using Stellar.Core.DomainLayer.EntityFrameworkCore.Converters;
using Stellar.Core.DomainLayer.EntityFrameworkCore.Utils;
using Stellar.Core.DomainLayer.ValueObjects;

using Throw;

namespace Stellar.Core.DomainLayer.EntityFrameworkCore.Extensions;

public static class ModelConfigurationBuilderExtensions
{
    public static void ConfigureSimpleValueObjects(this ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.ThrowIfNull();

        var modelBuilder = configurationBuilder.CreateModelBuilder(null);

        var propertyTypes = modelBuilder.Model.GetEntityTypes()
            .SelectMany(e => e.ClrType.GetProperties())
            .Select(p =>
            {
                var pt = p.PropertyType;
                pt.InheritsFromGeneric(typeof(SimpleValueObject<,>), out var t);
                return new { Type = pt, SimpleValueObjectType = t! };
            })
            .Where(x => x.SimpleValueObjectType != null)
            .DistinctBy(x => x.Type);

        foreach (var propertyType in propertyTypes)
        {
            var valueType = propertyType.SimpleValueObjectType.GetGenericArguments()[1];
            var converterType = typeof(SimpleValueObjectConverter<,>).MakeGenericType(propertyType.Type, valueType);

            configurationBuilder.Properties(propertyType.Type)
                                .HaveConversion(converterType);
        }
    }
}