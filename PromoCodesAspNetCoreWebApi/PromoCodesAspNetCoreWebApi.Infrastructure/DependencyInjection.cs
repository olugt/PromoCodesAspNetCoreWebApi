using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PromoCodesAspNetCoreWebApi.Application.Common.Interfaces.Infrastructure;
using PromoCodesAspNetCoreWebApi.Infrastructure.IdentityManagement;
using System;
using System.Collections.Generic;
using System.Text;

namespace PromoCodesAspNetCoreWebApi.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IJwtManager, JwtManager>();
            services.AddTransient<ICurrentUser, CurrentUser>();

            return services;
        }
    }
}
