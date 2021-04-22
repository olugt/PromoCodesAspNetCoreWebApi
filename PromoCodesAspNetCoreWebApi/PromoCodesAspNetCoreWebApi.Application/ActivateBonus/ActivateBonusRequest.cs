using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace PromoCodesAspNetCoreWebApi.Application.ActivateBonus
{
    public class ActivateBonusRequest: IRequest<ActivateBonusResponse>
    {
        public int ServiceId { get; set; }
    }
}
