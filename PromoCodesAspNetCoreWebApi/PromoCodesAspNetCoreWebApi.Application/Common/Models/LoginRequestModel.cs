using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PromoCodesAspNetCoreWebApi.Application.Common.Models
{
    public class LoginRequestModel
    {
        [Required(ErrorMessage = "Email address is required.")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
