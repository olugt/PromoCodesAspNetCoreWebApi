using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using PromoCodesAspNetCoreWebApi.Application.Common.Models.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PromoCodesAspNetCoreWebApi.WebApi.ConfigurationManagement
{
    /// <summary>
    /// Configure options for JWT details.
    /// </summary>
    public class ConfigureJwtDetailOptions : IConfigureOptions<JwtDetailOptions>
    {
        private readonly IConfiguration configuration;

        public ConfigureJwtDetailOptions(
            IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void Configure(JwtDetailOptions options)
        {
            configuration.GetSection("ConfigurationOptions:JwtDetailOptions").Bind(options);
        }
    }
}
