﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PromoCodesAspNetCoreWebApi.Common.Extensions
{
    public static class ExceptionExtensions
    {
        /// <summary>
        /// Gets exception data as generic dictionary.
        /// </summary>
        /// <param name="ex">The exception.</param>
        /// <returns>Returns generic dictionary.</returns>
        public static Dictionary<string, object> GetData(this Exception ex)
        {
            if (ex.Data.Count > 0)
                return ex.Data.Keys.Cast<string>().ToDictionary(key => key, key => ex.Data[key]);

            return new Dictionary<string, object>();
        }
    }
}
