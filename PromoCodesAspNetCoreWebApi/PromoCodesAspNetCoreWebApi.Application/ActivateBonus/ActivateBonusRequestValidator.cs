using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace PromoCodesAspNetCoreWebApi.Application.ActivateBonus
{
    public class ActivateBonusRequestValidator: AbstractValidator<ActivateBonusRequest>
    {
        public ActivateBonusRequestValidator()
        {
            RuleFor(a => a.ServiceId)
                .NotEmpty()
                .WithMessage("Identify the service about which bonus is to be activated for the user.");
        }
    }
}
