using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PromoCodesAspNetCoreWebApi.Application.Common.Interfaces;
using PromoCodesAspNetCoreWebApi.Application.Common.Pipelines;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace PromoCodesAspNetCoreWebApi.Application
{
    public static class DependencyInjection
    {
        /// <summary>
        /// Register dependencies at the Application layer, with the service collection.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingPipeline<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipeline<,>));

            AssemblyScanner.FindValidatorsInAssemblyContaining(typeof(IMarkerInterface)).ForEach(a => services.AddTransient(a.InterfaceType, a.ValidatorType));

            return services;
        }
    }
}
