﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PromoCodesAspNetCoreWebApi.Application.Common.Models
{
    public class LoginBinderModel
    {
        public string EmailAddress { get; set; }
        public string Password { get; set; }
    }
}
