﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Stellar.IS.Infrastructure.Persistence;

#nullable disable

namespace Stellar.IS.Migrations.Migrations
{
    [DbContext(typeof(StellarDbContext))]
    partial class StellarDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.8");

            modelBuilder.Entity("Stellar.IS.Domain.Users.User", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("TEXT")
                        .HasColumnName("id");

                    b.Property<int>("ActivityStatus")
                        .HasColumnType("INTEGER")
                        .HasColumnName("activity_status");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("username");

                    b.HasKey("Id")
                        .HasName("pk_users");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("Stellar.IS.Domain.Users.User", b =>
                {
                    b.OwnsOne("Stellar.IS.Domain.Users.ValueObjects.UserPasswordInfo", "PasswordInfo", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("TEXT")
                                .HasColumnName("id");

                            b1.Property<string>("Hash")
                                .IsRequired()
                                .HasColumnType("TEXT")
                                .HasColumnName("password_info_hash");

                            b1.Property<byte[]>("Salt")
                                .IsRequired()
                                .HasColumnType("BLOB")
                                .HasColumnName("password_info_salt");

                            b1.HasKey("UserId");

                            b1.ToTable("users");

                            b1.WithOwner()
                                .HasForeignKey("UserId")
                                .HasConstraintName("fk_users_users_id");
                        });

                    b.Navigation("PasswordInfo")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
