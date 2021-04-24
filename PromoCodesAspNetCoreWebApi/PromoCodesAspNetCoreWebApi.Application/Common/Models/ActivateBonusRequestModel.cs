using System;
using System.Collections.Generic;
using System.Text;

namespace PromoCodesAspNetCoreWebApi.Application.Common.Models
{
    public class ActivateBonusRequestModel
    {
        public int ServiceId { get; set; }
        public string PromoCode { get; set; }
    }
}
