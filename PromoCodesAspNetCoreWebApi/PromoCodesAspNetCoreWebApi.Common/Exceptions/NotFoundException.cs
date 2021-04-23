using System;
using System.Collections.Generic;
using System.Text;

namespace PromoCodesAspNetCoreWebApi.Common.Exceptions
{
    /// <summary>
    /// Custom exception about HTTP Not Found error.
    /// </summary>
    public class NotFoundException : Exception
    {
        public NotFoundException() : base("Not found.")
        {
        }

        public NotFoundException(string message)
            : base(message)
        {
        }

        public NotFoundException(string dataName, object dataKey)
            : base($"\"{dataName}\" ({dataKey}) data not found.")
        {
        }
    }
}
