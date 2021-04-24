using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using PromoCodesAspNetCoreWebApi.Application;
using PromoCodesAspNetCoreWebApi.Application.Common.Models.Infrastructure;
using PromoCodesAspNetCoreWebApi.Infrastructure;
using PromoCodesAspNetCoreWebApi.Persistence;
using PromoCodesAspNetCoreWebApi.WebApi.ConfigurationManagement;
using PromoCodesAspNetCoreWebApi.WebApi.Middleware.Extensions;
using PromoCodesAspNetCoreWebApi.WebApi.ResponseProviders;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace PromoCodesAspNetCoreWebApi.WebApi
{
    public class Startup
    {
        public Startup(
            IConfiguration configuration,
            IHostEnvironment hostEnvironment)
        {
            Configuration = configuration;
            HostEnvironment = hostEnvironment;
        }

        public IConfiguration Configuration { get; }
        public IHostEnvironment HostEnvironment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IConfigureOptions<JwtDetailOptions>, ConfigureJwtDetailOptions>();
            services.AddTransient<JwtDetailConfigurationManager>();

            services.AddHttpContextAccessor();

            services.AddInfrastructure(Configuration);
            services.AddPersistence(Configuration);
            services.AddApplication(Configuration);

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(corsPolicyBuilder =>
                {
                    corsPolicyBuilder.WithOrigins(Configuration.GetSection("CorsOrigins").Get<string[]>())
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });

            services.AddControllers()
                .ConfigureApiBehaviorOptions(options =>
                {
                    options.SuppressModelStateInvalidFilter = true;
                });
            services.AddApiVersioning(options =>
            {
                options.ReportApiVersions = true;
                options.ErrorResponses = new ApiVersionExceptionResponseProvider();
            });
            services.AddVersionedApiExplorer(options => options.GroupNameFormat = "'v'VVV");

            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerGenOptions>();

            services.AddOptions<JwtBearerOptions>(JwtBearerDefaults.AuthenticationScheme)
                .Configure<JwtDetailConfigurationManager>((options, jwtConfigurationManager) =>
                {
                    var jwtManagementOptions = jwtConfigurationManager.GetJwtDetailOptions();

                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        RequireExpirationTime = true,
                        RequireSignedTokens = true,
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jwtManagementOptions.Issuer,
                        ValidAudiences = jwtManagementOptions.Audiences,
                        IssuerSigningKey = jwtConfigurationManager.GetSecurityKey(),
                        IssuerSigningKeyResolver = new IssuerSigningKeyResolver(jwtConfigurationManager.GetIssuerSigningKeyResolver)
                    };
                });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer();

            services.AddAuthorization();

            services.AddSwaggerGen(options =>
            {
                options.ResolveConflictingActions(apiDescription => apiDescription.First());
                options.IncludeXmlComments(
                    Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"),
                    includeControllerXmlComments: true
                    );

                options.AddSecurityDefinition("JWT_Bearer_Token_Authentication", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = JwtBearerDefaults.AuthenticationScheme,
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Bearer token Open API security scheme."
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "JWT_Bearer_Token_Authentication"
                            }
                        },
                        new string[] { }
                    }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(
            IApplicationBuilder app,
            IWebHostEnvironment env,
            IApiVersionDescriptionProvider provider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseExceptionTransformer();

            app.UseCors();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(
                options =>
                {
                    foreach (var description in provider.ApiVersionDescriptions)
                    {
                        options.SwaggerEndpoint(
                            $"/swagger/{description.GroupName}/swagger.json",
                            description.GroupName.ToUpperInvariant());
                    }
                });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
