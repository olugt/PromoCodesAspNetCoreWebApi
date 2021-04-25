using System;
using System.Collections.Generic;
using System.Text;

namespace PromoCodesAspNetCoreWebApi.Common.Exceptions
{
    /// <summary>
    /// Custom exception about general validation error.
    /// </summary>
    public class ValidationException : Exception
    {
        public ValidationException()
            : base("Validation error occurred.")
        {
        }

        public ValidationException(string message)
            : base(message)
        {
        }
    }
}
