using System;
using System.Collections.Generic;
using System.Text;

namespace PromoCodesAspNetCoreWebApi.Application.Common.Interfaces.Infrastructure
{
    /// <summary>
    /// Current user.
    /// </summary>
    public interface ICurrentUser
    {
        public string GetEmailAddress();
    }
}
