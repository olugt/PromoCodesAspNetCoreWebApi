using System;
using System.Collections.Generic;
using System.Text;

namespace PromoCodesAspNetCoreWebApi.Application.Common.Models
{
    public class ValidationErrorResponseModel : ErrorResponseModel<string[]>
    {
        public override Dictionary<string, string[]> Data { get => base.Data; set => base.Data = value; }
    }
}
