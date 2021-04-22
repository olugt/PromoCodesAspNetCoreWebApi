using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace PromoCodesAspNetCoreWebApi.Persistence
{
    public static class DatabaseLogic
    {
        public static void Initialize<TDbContext>(IServiceProvider serviceProvider) where TDbContext : DbContext
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<TDbContext>();
                dbContext.Database.EnsureDeleted();
                dbContext.Database.Migrate();
            }
        }
    }
}
