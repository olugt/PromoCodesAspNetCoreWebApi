using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using PromoCodesAspNetCoreWebApi.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PromoCodesAspNetCoreWebApi.WebApi.Extensions
{
    public static class ActionContextExtensions
    {
        public static ValidationException ToValidationException(this ModelStateDictionary modelState)
        {
            if (modelState.IsValid)
            {
                throw new InvalidOperationException("Model state is valid. Use this extension where it is guaranteed model state is invalid.");
            }

            var entries = modelState.Where(a => a.Value.ValidationState == ModelValidationState.Invalid).Select(b => new KeyValuePair<string, string[]>(b.Key, b.Value.Errors.Select(c => c.ErrorMessage).ToArray()));
            var valdEx = new ValidationException("Check for invalid data.");
            foreach (var entry in entries)
            {
                valdEx.Data.Add(entry.Key, entry.Value);
            }

            return valdEx;
        }
    }
}
