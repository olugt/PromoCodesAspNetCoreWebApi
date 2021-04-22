using System;
using System.Collections.Generic;
using System.Text;

namespace PromoCodesAspNetCoreWebApi.Application.Common.Models.Infrastructure
{
    public class JwtDetailOptions
    {
        public string[] Audiences { get; set; }
        public string Issuer { get; set; }
        public int ExpiryDurationMinutes { get; set; }
        public string SymmetricSecurityKeyBase64 { get; set; }
    }
}
