using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PromoCodesAspNetCoreWebApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PromoCodesAspNetCoreWebApi.Persistence.PromoCodesAspNetCoreWebApiDb.Configuration
{
    public class ServiceCongfiguration : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.ToTable(nameof(Service)).HasIndex(a => a.Name).IsUnique();
            builder.ToTable(nameof(Service)).Property(a => a.Name).IsRequired();

            builder.ToTable(nameof(Service)).HasData(
                new Service
                {
                    ServiceId = 1,
                    Name = "Service 1"
                },
                new Service
                {
                    ServiceId = 2,
                    Name = "Service 2"
                },
                new Service
                {
                    ServiceId = 3,
                    Name = "Service 3"
                },
                new Service
                {
                    ServiceId = 4,
                    Name = "Service 4"
                },
                new Service
                {
                    ServiceId = 5,
                    Name = "Service 5"
                },
                new Service
                {
                    ServiceId = 6,
                    Name = "Service 6"
                },
                new Service
                {
                    ServiceId = 7,
                    Name = "Service 7"
                },
                new Service
                {
                    ServiceId = 8,
                    Name = "Service 8"
                },
                new Service
                {
                    ServiceId = 9,
                    Name = "Service 9"
                },
                new Service
                {
                    ServiceId = 10,
                    Name = "Service 10"
                },
                new Service
                {
                    ServiceId = 11,
                    Name = "Service 11"
                },
                new Service
                {
                    ServiceId = 12,
                    Name = "Service 12"
                },
                new Service
                {
                    ServiceId = 13,
                    Name = "Service 13"
                });
        }
    }
}
