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

            var seedData = new Service[]
            {
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
                },
                new Service
                {
                    ServiceId = 14,
                    Name = "Service 14"
                },
                new Service
                {
                    ServiceId = 15,
                    Name = "Service 15"
                },
                new Service
                {
                    ServiceId = 16,
                    Name = "Service 16"
                },
                new Service
                {
                    ServiceId = 17,
                    Name = "Service 17"
                },
                new Service
                {
                    ServiceId = 18,
                    Name = "Service 18"
                },
                new Service
                {
                    ServiceId = 19,
                    Name = "Service 19"
                },
                new Service
                {
                    ServiceId = 20,
                    Name = "Service 20"
                },
                new Service
                {
                    ServiceId = 21,
                    Name = "Service 21"
                },
                new Service
                {
                    ServiceId = 22,
                    Name = "Service 22"
                },
                new Service
                {
                    ServiceId = 23,
                    Name = "Service 23"
                },
                new Service
                {
                    ServiceId = 24,
                    Name = "Service 24"
                },
                new Service
                {
                    ServiceId = 25,
                    Name = "Service 25"
                },
                new Service
                {
                    ServiceId = 26,
                    Name = "Service 26"
                },
                new Service
                {
                    ServiceId = 27,
                    Name = "Service 27"
                },
                new Service
                {
                    ServiceId = 28,
                    Name = "Service 28"
                },
                new Service
                {
                    ServiceId = 29,
                    Name = "Service 29"
                },
                new Service
                {
                    ServiceId = 30,
                    Name = "Service 30"
                }
            };
            builder.ToTable(nameof(Service)).HasData(seedData);
        }
    }
}
