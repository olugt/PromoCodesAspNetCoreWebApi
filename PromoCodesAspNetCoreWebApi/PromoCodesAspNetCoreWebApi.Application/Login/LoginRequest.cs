using MediatR;
using PromoCodesAspNetCoreWebApi.Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PromoCodesAspNetCoreWebApi.Application.Login
{
    public class LoginRequest : IRequest<LoginResponse>
    {
        public LoginRequestModel RequestModel { get; set; }
    }
}
