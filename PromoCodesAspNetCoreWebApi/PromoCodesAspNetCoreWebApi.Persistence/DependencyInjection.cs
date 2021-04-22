using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PromoCodesAspNetCoreWebApi.Application.Common.Interfaces.Infrastructure;
using PromoCodesAspNetCoreWebApi.Persistence.PromoCodesAspNetCoreWebApiDb;
using System;
using System.Collections.Generic;
using System.Text;

namespace PromoCodesAspNetCoreWebApi.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PromoCodesAspNetCoreWebApiDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("PromoCodesAspNetCoreWebApiDb")), ServiceLifetime.Transient);

            services.AddScoped(typeof(IRepository<>), typeof(PromoCodesAspNetCoreWebApiDbRepository<>));

            return services;
        }
    }
}
