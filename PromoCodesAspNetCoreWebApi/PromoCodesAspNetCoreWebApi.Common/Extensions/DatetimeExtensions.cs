using System;
using System.Collections.Generic;
using System.Text;

namespace PromoCodesAspNetCoreWebApi.Common.Extensions
{
    public static class DatetimeExtensions
    {
        public static DateTime EnsureKind(this DateTime dateTime, DateTimeKind kind)
        {
            if (dateTime.Kind != kind)
            {
                throw new InvalidOperationException($"Date-time of kind {kind} expected.");
            }
            return dateTime;
        }
    }
}
