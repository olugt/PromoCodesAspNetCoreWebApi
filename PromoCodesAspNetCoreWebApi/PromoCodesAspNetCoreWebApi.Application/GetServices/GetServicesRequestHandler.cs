
using MediatR;
using PromoCodesAspNetCoreWebApi.Application.Common.Interfaces.Infrastructure;
using PromoCodesAspNetCoreWebApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PromoCodesAspNetCoreWebApi.Application.GetServices
{
    public class GetServicesRequestHandler : IRequestHandler<GetServicesRequest, GetServicesResponse>
    {
        private readonly IRepository<Service> repository;

        public GetServicesRequestHandler(
            IRepository<Service> repository)
        {
            this.repository = repository;
        }

        public Task<GetServicesResponse> Handle(GetServicesRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
