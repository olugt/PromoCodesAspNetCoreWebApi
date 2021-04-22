using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace PromoCodesAspNetCoreWebApi.Application.Common.Models
{
    public class PaginationBinderModelValidator: AbstractValidator<PaginationBinderModel>
    {
        public PaginationBinderModelValidator()
        {
            RuleFor(a => a.Page)
                .NotEmpty()
                .WithMessage("Page number is rquired if pagination is in use.");

            RuleFor(a => a.Limit)
                .NotEmpty()
                .WithMessage("Page items limit is rquired if pagination is in use.");
        }
    }
}
