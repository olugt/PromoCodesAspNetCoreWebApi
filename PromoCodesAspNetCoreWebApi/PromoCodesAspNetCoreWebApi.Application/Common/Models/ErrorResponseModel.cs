using System;
using System.Collections.Generic;
using System.Text;

namespace PromoCodesAspNetCoreWebApi.Application.Common.Models
{
    public class ErrorResponseModel<TDataValue>
    {
        public string Message { get; set; }
        public virtual Dictionary<string, TDataValue> Data { get; set; }
    }
}
