using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PromoCodesAspNetCoreWebApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PromoCodesAspNetCoreWebApi.Persistence.PromoCodesAspNetCoreWebApiDb.Configuration
{
    public class BonusConfiguration : IEntityTypeConfiguration<Bonus>
    {
        public void Configure(EntityTypeBuilder<Bonus> builder)
        {
            //builder.ToTable(nameof(Bonus)).HasIndex(a => new { a.UserId, a.ServiceId }).IsUnique();
            //builder.ToTable(nameof(Bonus)).Property(a => a.Amount).IsRequired();
            builder.ToTable(nameof(Bonus)).Property(a => a.UserId).IsRequired();
            builder.ToTable(nameof(Bonus)).Property(a => a.ServiceId).IsRequired();

            var seedData = new Bonus[]
            {
                new Bonus
                {
                    BonusId = 1,
                    Amount = 12.3M,
                    UserId = 1,
                    ServiceId = 1
                },
                new Bonus
                {
                    BonusId = 2,
                    Amount = 23.4M,
                    UserId = 1,
                    ServiceId = 4
                },
                new Bonus
                {
                    BonusId = 3,
                    Amount = 45.6M,
                    UserId = 1,
                    ServiceId = 7
                },
                new Bonus
                {
                    BonusId = 4,
                    Amount = 56.7M,
                    UserId = 1,
                    ServiceId = 10
                }
            };
            builder.ToTable(nameof(Bonus)).HasData(seedData);
        }
    }
}
