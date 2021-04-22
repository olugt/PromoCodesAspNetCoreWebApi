using MediatR;
using PromoCodesAspNetCoreWebApi.Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PromoCodesAspNetCoreWebApi.Application.RegisterUser
{
    public class RegisterUserRequest : IRequest<RegisterUserResponse>
    {
        public RegisterBinderModel BinderModel { get; set; }
    }
}
