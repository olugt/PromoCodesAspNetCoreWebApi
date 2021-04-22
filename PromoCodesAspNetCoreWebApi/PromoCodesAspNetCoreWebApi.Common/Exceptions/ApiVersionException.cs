using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace PromoCodesAspNetCoreWebApi.Common.Exceptions
{
    /// <summary>
    /// Custom exception about Web API versioning error.
    /// </summary>
    public class ApiVersionException : Exception
    {
        public const string MessageDetail = nameof(MessageDetail);
        public const string ErrorCode = nameof(ErrorCode);
        public const string StatusCode = nameof(StatusCode);

        public ApiVersionException(string message, string messageDetail, string errorCode, HttpStatusCode statusCode)
            : base(message)
        {
            Data.Add(MessageDetail, messageDetail);
            Data.Add(ErrorCode, errorCode);
            Data.Add(StatusCode, statusCode);
        }
    }
}
