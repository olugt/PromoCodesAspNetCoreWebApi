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
        private JwtDetailOptions jwtDetailOptions;

        public JwtManager(
            IOptionsMonitor<JwtDetailOptions> jwtDetailOptionsMonitor)
        {
            jwtDetailOptions = jwtDetailOptionsMonitor.CurrentValue;
        }
        public Task<JwtDetail> GenerateJwtDetails(IEnumerable<Claim> claims)
        {
            // This adds claims to represent account for multiple audiences. It is expected that the consumer of the JWT should check the audience.
            var jwtClaims = claims.Concat(jwtDetailOptions.Audiences.Select(a => new Claim(StandardClaimTypeConstants.Aud, a)));

            var securityKey = new SymmetricSecurityKey(Convert.FromBase64String(jwtDetailOptions.SecurityKeyBase64));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);


            var expiryDatetimeUtc = DateTime.UtcNow.AddMinutes(jwtDetailOptions.ExpiryDurationMinutes);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: jwtDetailOptions.Issuer,
                audience: null,
                claims: jwtClaims,
                notBefore: expiryDatetimeUtc.AddMinutes(-jwtDetailOptions.ExpiryDurationMinutes),
                expires: expiryDatetimeUtc,
                signingCredentials: signingCredentials
                );

            return Task.FromResult(new JwtDetail(new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken), expiryDatetimeUtc));
        }
    }
}
