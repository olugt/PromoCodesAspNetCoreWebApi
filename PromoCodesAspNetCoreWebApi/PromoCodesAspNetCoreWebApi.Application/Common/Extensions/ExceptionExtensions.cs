using PromoCodesAspNetCoreWebApi.Common.Exceptions;
using PromoCodesAspNetCoreWebApi.Common.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PromoCodesAspNetCoreWebApi.Application.Common.Extensions
{
    public static class ExceptionExtensions
    {
        /// <summary>
        /// Gets detailed message about the exception.
        /// </summary>
        /// <param name="ex">The exception.</param>
        /// <param name="getMore">About if more details should be gotten about the exception.</param>
        /// <returns>Returns details gotten about the exception.</returns>
        public static string GetDetailedMessage(this Exception ex, bool getMore = false)
        {
            if (ex is ValidationException valEx)
            {
                var data = valEx.GetData();
                if (data.Any())
                    return $"{ex.Message}\n{string.Join("\n", data.Select(a => string.Join("\n", ((string[])a.Value).Select(b => (getMore ? $"{a.Key}: " : string.Empty) + b))))}";
            }
            else if (ex is ApiVersionException apiVerEx)
            {
                return (string)apiVerEx.Data[ApiVersionException.MessageDetail];
            }

            return ex.Message;
        }

        /// <summary>
        /// Transforms an exception into a custom identity-related exception.
        /// </summary>
        /// <param name="ex">The exception.</param>
        /// <param name="message">Exception message.</param>
        /// <returns>Identity-related exception.</returns>
        public static IdentityException ToIdentityExeption(this Exception ex, string message = null)
        {
            return new IdentityException(message, ex);
        }
    }
}
