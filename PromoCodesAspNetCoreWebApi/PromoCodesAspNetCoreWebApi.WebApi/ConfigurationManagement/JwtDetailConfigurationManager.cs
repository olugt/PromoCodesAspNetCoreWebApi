using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PromoCodesAspNetCoreWebApi.Application.Common.Models.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromoCodesAspNetCoreWebApi.WebApi.ConfigurationManagement
{
    public class JwtDetailConfigurationManager
    {
        private readonly IServiceProvider serviceProvider;

        public JwtDetailConfigurationManager(
            IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public JwtDetailOptions GetJwtDetailOptions()
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var jwtDetailOptionsSnapshot = scope.ServiceProvider.GetRequiredService<IOptionsSnapshot<JwtDetailOptions>>();
                return jwtDetailOptionsSnapshot.Value;
            }
        }

        public SecurityKey GetSecurityKey()
        {
            return new SymmetricSecurityKey(Convert.FromBase64String(GetJwtDetailOptions().SecurityKey)); ;
        }

        public IEnumerable<SecurityKey> IssuerSigningKeyResolver(string token, SecurityToken securityToken, string kid, TokenValidationParameters validationParameters)
        {
            return new List<SecurityKey>() { GetSecurityKey() };
        }
    }
}
