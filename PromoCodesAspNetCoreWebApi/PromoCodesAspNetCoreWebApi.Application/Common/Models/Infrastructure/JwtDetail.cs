using PromoCodesAspNetCoreWebApi.Common.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace PromoCodesAspNetCoreWebApi.Application.Common.Models.Infrastructure
{
    public class JwtDetail
    {
        public JwtDetail(string jwt, DateTime expiryDatetimeUtc)
        {
            Jwt = jwt;
            ExpiryDatetimeUtc = expiryDatetimeUtc.EnsureKind(DateTimeKind.Utc);
        }

        public string Jwt { get; }
        public DateTime ExpiryDatetimeUtc { get; }
    }
}
