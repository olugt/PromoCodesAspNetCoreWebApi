using System;
using System.Collections.Generic;
using System.Text;

namespace PromoCodesAspNetCoreWebApi.Application.Common.Interfaces
{
    public interface ICurrentUser
    {
        public string EmailAddress { get; set; }
        public string NormalizedIdentifier { get; set; }
    }
}
