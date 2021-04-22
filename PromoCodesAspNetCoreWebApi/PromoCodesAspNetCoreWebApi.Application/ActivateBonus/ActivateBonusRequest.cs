using MediatR;
using PromoCodesAspNetCoreWebApi.Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PromoCodesAspNetCoreWebApi.Application.ActivateBonus
{
    public class ActivateBonusRequest: IRequest<ActivateBonusResponse>
    {
        public ActivateBonusBinderModel BinderModel { get; set; }
    }
}
