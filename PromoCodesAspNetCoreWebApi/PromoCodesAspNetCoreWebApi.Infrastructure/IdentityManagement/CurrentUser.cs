using Microsoft.AspNetCore.Http;
using PromoCodesAspNetCoreWebApi.Application.Common.Interfaces.Infrastructure;
using PromoCodesAspNetCoreWebApi.Infrastructure.IdentityManagement.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace PromoCodesAspNetCoreWebApi.Infrastructure.IdentityManagement
{
    public class CurrentUser : ICurrentUser
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public CurrentUser(
            IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        public string GetEmailAddress()
        {
            if (httpContextAccessor.HttpContext.User != null)
            {
                return httpContextAccessor.HttpContext.User.FindFirst(CustomClaimTypesConstants.EmailAddress).Value;
            }
            return null;
        }
    }
}
