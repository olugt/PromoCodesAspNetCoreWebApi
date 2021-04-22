
using AutoMapper;
using MediatR;
using PromoCodesAspNetCoreWebApi.Application.Common.Interfaces.Infrastructure;
using PromoCodesAspNetCoreWebApi.Application.Common.Models;
using PromoCodesAspNetCoreWebApi.Common.Exceptions;
using PromoCodesAspNetCoreWebApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PromoCodesAspNetCoreWebApi.Application.GetServices
{
    public class GetServicesRequestHandler : IRequestHandler<GetServicesRequest, GetServicesResponse>
    {
        private readonly IMapper mapper;
        private readonly IRepository<Service> serviceRepo;

        public GetServicesRequestHandler(
            IMapper mapper,
            IRepository<Service> serviceRepo)
        {
            this.mapper = mapper;
            this.serviceRepo = serviceRepo;
        }

        public Task<GetServicesResponse> Handle(GetServicesRequest request, CancellationToken cancellationToken)
        {
            var services = serviceRepo.Query().Skip(request.Pagination.Skip).Take(request.Pagination.Limit);
            if (!services.Any())
                throw new NotFoundException("No services available.");

            var serviceModels = mapper.ProjectTo<ServiceModel>(services).ToList();
            return Task.FromResult(new GetServicesResponse { Services = serviceModels });
        }
    }
}
