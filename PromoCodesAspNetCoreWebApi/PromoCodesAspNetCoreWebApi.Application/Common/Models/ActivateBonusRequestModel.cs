using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PromoCodesAspNetCoreWebApi.Application.Common.Models
{
    public class ActivateBonusRequestModel
    {
        [Required(ErrorMessage = "Identify the service about which bonus is to be activated for the user.")]
        public int? ServiceId { get; set; }
        [Required(ErrorMessage = "Valid promo code is required.")]
        public string PromoCode { get; set; }
    }
}
