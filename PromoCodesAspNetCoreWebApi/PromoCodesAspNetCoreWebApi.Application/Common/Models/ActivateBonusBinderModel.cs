using System;
using System.Collections.Generic;
using System.Text;

namespace PromoCodesAspNetCoreWebApi.Application.Common.Models
{
    public class ActivateBonusBinderModel
    {
        public int ServiceId { get; set; }
        public string PromoCode { get; set; }
    }
}
