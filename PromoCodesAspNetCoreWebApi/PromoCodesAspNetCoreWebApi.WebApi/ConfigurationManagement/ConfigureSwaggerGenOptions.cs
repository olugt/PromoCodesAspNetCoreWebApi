using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PromoCodesAspNetCoreWebApi.WebApi.ConfigurationManagement
{
    /// <summary>
    /// Configure options for Swagger.
    /// </summary>
    public class ConfigureSwaggerGenOptions : IConfigureOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider provider;
        private readonly IConfiguration configuration;

        public ConfigureSwaggerGenOptions(
            IApiVersionDescriptionProvider provider,
            IConfiguration configuration)
        {
            this.provider = provider;
            this.configuration = configuration;
        }

        public void Configure(SwaggerGenOptions options)
        {
            var openApiContact = new OpenApiContact()
            {
                Name = configuration["ConfigurationOptions:SwaggerGenOptions:OpenApiContact_Name"],
                Email = configuration["ConfigurationOptions:SwaggerGenOptions:OpenApiContact_Email"],
                Url = new Uri(configuration["ConfigurationOptions:SwaggerGenOptions:CompanyUrl"])
            };

            var openApiLicense = new OpenApiLicense()
            {
                Name = configuration["ConfigurationOptions:SwaggerGenOptions:OpenApiLicense_Name"],
                Url = new Uri(configuration["ConfigurationOptions:SwaggerGenOptions:CompanyUrl"])
            };

            foreach (var description in provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(
                  description.GroupName,
                    new OpenApiInfo()
                    {
                        Title = $"{configuration["ConfigurationOptions:SwaggerGenOptions:ProjectName"]} {description.ApiVersion}",
                        Version = description.ApiVersion.ToString(),
                        Description = configuration["ConfigurationOptions:SwaggerGenOptions:ProjectDescription"],
                        TermsOfService = new Uri(configuration["ConfigurationOptions:SwaggerGenOptions:CompanyUrl"]),
                        Contact = openApiContact,
                        License = openApiLicense
                    });
            }
        }
    }
}
