using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PromoCodesAspNetCoreWebApi.Application.Common.Logic;
using PromoCodesAspNetCoreWebApi.Application.Common.Models;
using PromoCodesAspNetCoreWebApi.Common.Exceptions;
using PromoCodesAspNetCoreWebApi.Common.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace PromoCodesAspNetCoreWebApi.WebApi.Middleware
{
    public class ExceptionTransformerMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<ExceptionTransformerMiddleware> logger;

        public ExceptionTransformerMiddleware(RequestDelegate next, ILogger<ExceptionTransformerMiddleware> logger)
        {
            this.next = next;
            this.logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Exception caught in exception transformer middeleware: {ex.Message}", null);

                await HandleAsync(context, ex);
            }
        }

        private async Task HandleAsync(HttpContext context, Exception ex)
        {
            var responseStatusCode = HttpStatusCode.InternalServerError;
            var responseText = string.Empty;

            if (ex is ValidationException valdEx)
            {
                responseStatusCode = HttpStatusCode.BadRequest;
                responseText = JsonConvert.SerializeObject(
                    new ValidationErrorResponseModel
                    {
                        Message = valdEx.Message,
                        Data = valdEx.GetData()
                    }, NewtonsoftLogic.GetCammelCaseSettings());
            }
            else
            {
                var (statusCode, data) = ex switch
                {
                    NotFoundException _ => (HttpStatusCode.NotFound, ex.GetData()),
                    ApiVersionException _ => ((HttpStatusCode)ex.GetData()[ApiVersionException.StatusCode], ex.GetData()),
                    IdentityException _ => (HttpStatusCode.Unauthorized, ex.GetData()),
                    _ => (HttpStatusCode.InternalServerError, null)
                };

                responseStatusCode = statusCode;
                responseText = JsonConvert.SerializeObject/*JsonSerializer.Serialize*/(
                new ErrorResponseModel<object>
                {
                    Message = statusCode == HttpStatusCode.InternalServerError ? "Operation failed." : ex.Message,
                    Data = data
                }, NewtonsoftLogic.GetCammelCaseSettings());
            }

            context.Response.StatusCode = (int)responseStatusCode;
            context.Response.ContentType = "application/json";

            await context.Response.WriteAsync(responseText);
        }
    }
}
