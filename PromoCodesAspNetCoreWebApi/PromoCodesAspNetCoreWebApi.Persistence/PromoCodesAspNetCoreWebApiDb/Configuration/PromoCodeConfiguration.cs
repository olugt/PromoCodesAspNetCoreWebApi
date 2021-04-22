using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PromoCodesAspNetCoreWebApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PromoCodesAspNetCoreWebApi.Persistence.PromoCodesAspNetCoreWebApiDb.Configuration
{
    public class PromoCodeConfiguration : IEntityTypeConfiguration<PromoCode>
    {
        public void Configure(EntityTypeBuilder<PromoCode> builder)
        {
            builder.ToTable(nameof(PromoCode)).HasIndex(a => a.Name).IsUnique();
            builder.ToTable(nameof(PromoCode)).Property(a => a.Name).IsRequired();

            builder.ToTable(nameof(PromoCode)).HasData(
                new PromoCode
                {
                    PromoCodeId = 1,
                    Name = "promo-code-1"
                },
                new PromoCode
                {
                    PromoCodeId = 2,
                    Name = "promo-code-2"
                },
                new PromoCode
                {
                    PromoCodeId = 3,
                    Name = "promo-code-3"
                },
                new PromoCode
                {
                    PromoCodeId = 4,
                    Name = "promo-code-4"
                },
                new PromoCode
                {
                    PromoCodeId = 5,
                    Name = "promo-code-5"
                },
                new PromoCode
                {
                    PromoCodeId = 6,
                    Name = "promo-code-6"
                });
        }
    }
}
