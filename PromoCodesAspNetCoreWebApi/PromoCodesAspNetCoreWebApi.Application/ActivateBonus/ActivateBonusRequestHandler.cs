using MediatR;
using PromoCodesAspNetCoreWebApi.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PromoCodesAspNetCoreWebApi.Application.ActivateBonus
{
    public class ActivateBonusRequestHandler : IRequestHandler<ActivateBonusRequest, ActivateBonusResponse>
    {
        private readonly ICurrentUser currentUser;

        public ActivateBonusRequestHandler(
            ICurrentUser currentUser)
        {
            this.currentUser = currentUser;
        }
        public Task<ActivateBonusResponse> Handle(ActivateBonusRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
