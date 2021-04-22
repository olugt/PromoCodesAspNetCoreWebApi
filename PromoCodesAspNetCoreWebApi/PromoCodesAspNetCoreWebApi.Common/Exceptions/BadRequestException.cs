using System;
using System.Collections.Generic;
using System.Text;

namespace PromoCodesAspNetCoreWebApi.Common.Exceptions
{
    /// <summary>
    /// Custom exception about HTTP Bad Request error.
    /// </summary>
    public class BadRequestException : Exception
    {
        public BadRequestException() : base("Bad request.")
        {
        }

        public BadRequestException(string message)
            : base(message)
        {
        }
    }
}
