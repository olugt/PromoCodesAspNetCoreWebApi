using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PromoCodesAspNetCoreWebApi.WebApi.Middleware.Extensions
{
    public static class ExceptionTransformerMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionTransformer(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionTransformerMiddleware>();
        }
    }
}
