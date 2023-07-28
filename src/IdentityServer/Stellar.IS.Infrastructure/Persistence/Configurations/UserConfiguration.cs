using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Stellar.IS.Domain.Users;

namespace Stellar.IS.Infrastructure.Persistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);

        builder.Property(u => u.Username)
            .IsRequired();

        builder.Property(u => u.Email)
            .IsRequired();

        builder.Property(u => u.ActivityStatus)
            .IsRequired();

        builder.OwnsOne(u => u.PasswordInfo, pi =>
        {
            pi.Property(u => u.Hash)
                .IsRequired();

            pi.Property(u => u.Salt)
                .IsRequired();
        });

        builder.HasIndex(u => u.Email)
            .IsUnique();
    }
}