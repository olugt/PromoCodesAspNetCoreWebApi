using System;
using System.Collections.Generic;
using System.Text;

namespace PromoCodesAspNetCoreWebApi.Common.Exceptions
{
    /// <summary>
    /// Custom exception about identity-related error.
    /// </summary>
    public class IdentityException : Exception
    {
        static string defaultMessage = "Identity error occurred.";

        public IdentityException() : base(defaultMessage)
        {

        }

        public IdentityException(string message) : base(defaultMessage + " " + message)
        {

        }

        public IdentityException(Exception exception) : base(defaultMessage, exception)
        {

        }

        public IdentityException(string message, Exception exception) : base(defaultMessage + " " + message, exception)
        {

        }
    }
}
