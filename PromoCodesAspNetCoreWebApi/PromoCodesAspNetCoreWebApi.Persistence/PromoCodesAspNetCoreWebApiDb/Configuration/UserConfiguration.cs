using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PromoCodesAspNetCoreWebApi.Application.Common.Logic;
using PromoCodesAspNetCoreWebApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PromoCodesAspNetCoreWebApi.Persistence.PromoCodesAspNetCoreWebApiDb.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable(nameof(User)).HasIndex(a => a.EmailAddress).IsUnique();
            builder.ToTable(nameof(User)).Property(a => a.EmailAddress).IsRequired();
            builder.ToTable(nameof(User)).Property(a => a.PasswordHashToBase64).IsRequired();

            var seedData = new User[]
            {
                new User
                {
                    UserId = 1,
                    EmailAddress = "user1@example.com",
                    PasswordHashToBase64 = CryptographyLogic.HashStringToSha256ToBase64("password123.ABC")
                },
                new User
                {
                    UserId = 2,
                    EmailAddress = "user2@example.com",
                    PasswordHashToBase64 = CryptographyLogic.HashStringToSha256ToBase64("password456.DEF")
                },
                new User
                {
                    UserId = 3,
                    EmailAddress = "user3@example.com",
                    PasswordHashToBase64 = CryptographyLogic.HashStringToSha256ToBase64("password789.GHI")
                }
            };
            builder.ToTable(nameof(User)).HasData(seedData);
        }
    }
}
