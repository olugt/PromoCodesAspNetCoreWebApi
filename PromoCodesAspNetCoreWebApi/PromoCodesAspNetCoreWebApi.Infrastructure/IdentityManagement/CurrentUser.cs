using Microsoft.AspNetCore.Http;
using PromoCodesAspNetCoreWebApi.Application.Common.Constants;
using PromoCodesAspNetCoreWebApi.Application.Common.Interfaces.Infrastructure;
using PromoCodesAspNetCoreWebApi.Common.Exceptions;
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
                return httpContextAccessor.HttpContext.User.FindFirst(CustomClaimTypeConstants.EmailAddress).Value;
            }
            throw new IdentityException("User login is invalid!");
        }
    }
}
