using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using PromoCodesAspNetCoreWebApi.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace PromoCodesAspNetCoreWebApi.WebApi.ResponseProviders
{
    /// <summary>
    /// This class is essentially to throw exception for HTTP status code that are not OK. A centralized exception wrapper is expected to wrap the raised exception.
    /// </summary>
    public class ApiVersionExceptionResponseProvider : DefaultErrorResponseProvider
    {
        public override IActionResult CreateResponse(ErrorResponseContext context)
        {
            if (context.StatusCode != (int)HttpStatusCode.OK)
            {
                throw new ApiVersionException(context.Message, context.MessageDetail, context.ErrorCode, (HttpStatusCode)context.StatusCode);
            }

            return base.CreateResponse(context);
        }
    }
}
