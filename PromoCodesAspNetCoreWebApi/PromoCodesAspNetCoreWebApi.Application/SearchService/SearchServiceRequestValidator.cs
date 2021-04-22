using FluentValidation;
using PromoCodesAspNetCoreWebApi.Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PromoCodesAspNetCoreWebApi.Application.SearchService
{
    public class SearchServiceRequestValidator : AbstractValidator<SearchServiceRequest>
    {
        public SearchServiceRequestValidator()
        {
            RuleFor(a => a.ServiceNameSnippet)
                .NotEmpty()
                .WithMessage("Service name snippet cannot be empty.");

            RuleFor(a => a.Pagination)
                .SetValidator(new PaginationModelValidator())
                .When(a => a.Pagination != null);
        }
    }
}
