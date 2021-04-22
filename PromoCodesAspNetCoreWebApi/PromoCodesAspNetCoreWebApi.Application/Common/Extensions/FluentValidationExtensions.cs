using FluentValidation;
using FluentValidation.Internal;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ValidationException = PromoCodesAspNetCoreWebApi.Common.Exceptions.ValidationException;

namespace PromoCodesAspNetCoreWebApi.Application.Common.Extensions
{
    public static class FluentValidationExtensions
    {
        /// <summary>
        /// Transforms an FluentValidation failures into a custom validation exception.
        /// </summary>
        /// <param name="failures">The FluenValidation failures.</param>
        /// <returns>Custom validation exception.</returns>
        public static ValidationException ToValidationException(this IEnumerable<ValidationFailure> failures)
        {
            var propertyNames = failures
                .Select(e => e.PropertyName)
                .Distinct();

            var valdEx = new ValidationException();
            foreach (var propertyName in propertyNames)
            {
                var propertyFailures = failures
                    .Where(e => e.PropertyName == propertyName)
                    .Select(e => e.ErrorMessage)
                    .ToArray();

                valdEx.Data.Add(propertyName, propertyFailures);
            }

            return valdEx;
        }

        /// <summary>
        /// An extension for FluentValidation IValidator.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="validator"></param>
        /// <param name="instance"></param>
        /// <param name="throwIfInvalid">Hints about if exception should be thrown if validation is invalid. Typically, this eventually causes an exception to be thrown.</param>
        /// <param name="sendDetailsToClientIfThrown">Hints about if validation error details should be sent to the client-side. Typically, this eventually causes a custom validation error to be raised.</param>
        /// <returns></returns>
        /// <exception cref="ValidationException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public static ValidationResult Validate<T>(this IValidator<T> validator, T instance, bool throwIfInvalid, bool sendDetailsToClientIfThrown = false)
        {
            var validationResult = validator.Validate(instance);
            return Process(validationResult, instance, throwIfInvalid, sendDetailsToClientIfThrown);
        }

        /// <summary>
        /// An extension for FluentValidation IValidator.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="validator"></param>
        /// <param name="instance"></param>
        /// <param name="options"></param>
        /// <param name="throwIfInvalid">Hints about if exception should be thrown if validation is invalid. Typically, this eventually causes an exception to be thrown.</param>
        /// <param name="sendDetailsToClientIfThrown">Hints about if validation error details should be sent to the client-side. Typically, this eventually causes an exception to be thrown.</param>
        /// <returns></returns>
        /// <exception cref="ValidationException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public static ValidationResult Validate<T>(this IValidator<T> validator, T instance, Action<ValidationStrategy<T>> options, bool throwIfInvalid, bool sendDetailsToClientIfThrown = false)
        {
            var validationResult = validator.Validate(instance, options);
            return Process(validationResult, instance, throwIfInvalid, sendDetailsToClientIfThrown);
        }

        /// <summary>
        /// Does common processing of some other extension methods of this class.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="validationResult"></param>
        /// <param name="instance"></param>
        /// <param name="throwIfInvalid"></param>
        /// <param name="throwValidationExceptionIfInvalid"></param>
        /// <returns>Fluent validation result or exceptions are thrown.</returns>
        /// <exception cref="ValidationException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        private static ValidationResult Process<T>(this ValidationResult validationResult, T instance, bool throwIfInvalid, bool throwValidationExceptionIfInvalid = false)
        {
            if (throwIfInvalid && !validationResult.IsValid)
            {
                var valdEx = validationResult.Errors.ToValidationException();

                if (throwValidationExceptionIfInvalid)
                {
                    throw valdEx;
                }
                else
                {
                    var invalidEx = new InvalidOperationException("Server error.", valdEx);
                    invalidEx.Data[nameof(instance)] = instance;
                    throw invalidEx;
                }
            }

            return validationResult;
        }
    }
}
