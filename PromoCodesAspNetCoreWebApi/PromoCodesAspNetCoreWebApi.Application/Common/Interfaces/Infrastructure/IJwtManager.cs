using PromoCodesAspNetCoreWebApi.Application.Common.Models.Infrastructure;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PromoCodesAspNetCoreWebApi.Application.Common.Interfaces.Infrastructure
{
    public interface IJwtManager
    {
        /// <summary>
        /// Generate JWT with other related details.
        /// </summary>
        /// <param name="claims">Claims to embed in the JWT.</param>
        /// <returns>JWT details.</returns>
        Task<JwtDetail> GenerateJwtDetails(IEnumerable<Claim> claims);
    }
}
