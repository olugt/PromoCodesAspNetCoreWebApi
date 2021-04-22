using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PromoCodesAspNetCoreWebApi.Application.Common.Interfaces.Infrastructure;
using PromoCodesAspNetCoreWebApi.Application.Common.Models.Infrastructure;
using PromoCodesAspNetCoreWebApi.Infrastructure.IdentityManagement.Constants;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PromoCodesAspNetCoreWebApi.Infrastructure.IdentityManagement
{
    public class JwtManager : IJwtManager
    {
        private JwtOptions jwtOptions;

        public JwtManager(
            IOptionsMonitor<JwtOptions> jwtOptionsMonitor)
        {
            jwtOptions = jwtOptionsMonitor.CurrentValue;
        }
        public Task<JwtDetail> GenerateJwtDetails(IEnumerable<Claim> claims)
        {
            // This adds claims to represent account for multiple audiences. It is expected that the consumer of the JWT should check the audience.
            var jwtClaims = claims.Concat(jwtOptions.Audiences.Select(a => new Claim(StandardClaimTypesConstants.Aud, a)));

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.SymmetricSecurityKey));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);


            var expiryDatetimeUtc = DateTime.UtcNow.AddMinutes(jwtOptions.ExpiryDurationMinutes);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: jwtOptions.Issuer,
                audience: null,
                claims: jwtClaims,
                notBefore: expiryDatetimeUtc.AddMinutes(-jwtOptions.ExpiryDurationMinutes),
                expires: expiryDatetimeUtc,
                signingCredentials: signingCredentials
                );

            return Task.FromResult(new JwtDetail(new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken), expiryDatetimeUtc));
        }
    }
}
