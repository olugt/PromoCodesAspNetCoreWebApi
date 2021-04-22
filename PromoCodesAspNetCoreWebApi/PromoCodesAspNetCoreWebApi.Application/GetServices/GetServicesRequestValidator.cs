using FluentValidation;
using PromoCodesAspNetCoreWebApi.Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PromoCodesAspNetCoreWebApi.Application.GetServices
{
    public class GetServicesRequestValidator: AbstractValidator<GetServicesRequest>
    {
        public GetServicesRequestValidator()
        {
            RuleFor(a => a.Pagination)
                .SetValidator(new PaginationBinderModelValidator())
                .When(a => a.Pagination != null);
        }
    }
}
