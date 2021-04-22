
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PromoCodesAspNetCoreWebApi.Application.GetServices
{
    public class GetServicesRequestHandler : IRequestHandler<GetServicesRequest, GetServicesResponse>
    {
        public Task<GetServicesResponse> Handle(GetServicesRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
