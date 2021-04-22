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
            builder.ToTable(nameof(Bonus));
        }
    }
}
