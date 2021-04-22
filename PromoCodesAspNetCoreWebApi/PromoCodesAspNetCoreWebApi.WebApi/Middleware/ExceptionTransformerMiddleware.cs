using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        private readonly RequestDelegate _next;

        public ExceptionTransformerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleAsync(context, ex);
            }
        }

        private async Task HandleAsync(HttpContext context, Exception ex)
        {
            var (statusCode, data) = ex switch
            {
                BadRequestException _ => (HttpStatusCode.BadRequest, ex.GetData()),
                ValidationException _ => (HttpStatusCode.BadRequest, ex.GetData()),
                NotFoundException _ => (HttpStatusCode.NotFound, ex.GetData()),
                ApiVersionException _ => ((HttpStatusCode)ex.GetData()[ApiVersionException.StatusCode], ex.GetData()),
                IdentityException _ => (HttpStatusCode.BadRequest, ex.GetData()),
                _ => (HttpStatusCode.InternalServerError, null)
            };

            context.Response.StatusCode = (int)statusCode;
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(JsonSerializer.Serialize(
                new ErrorModel
                {
                    Message = statusCode == HttpStatusCode.InternalServerError ? "Operation failed." : ex.Message,
                    Data = data
                }));
        }
    }
}
