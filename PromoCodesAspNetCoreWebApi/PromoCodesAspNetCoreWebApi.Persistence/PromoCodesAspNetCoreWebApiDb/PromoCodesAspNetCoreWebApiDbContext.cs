using Microsoft.EntityFrameworkCore;
using PromoCodesAspNetCoreWebApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PromoCodesAspNetCoreWebApi.Persistence.PromoCodesAspNetCoreWebApiDb
{
    public class PromoCodesAspNetCoreWebApiDbContext : DbContext
    {
        public PromoCodesAspNetCoreWebApiDbContext(DbContextOptions<PromoCodesAspNetCoreWebApiDbContext> options) : base(options) { }

        public DbSet<Bonus> Bonuses { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<PromoCode> PromoCodes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PromoCodesAspNetCoreWebApiDbContext).Assembly);
        }
    }
}
