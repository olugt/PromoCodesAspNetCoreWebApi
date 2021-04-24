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

namespace PromoCodesAspNetCoreWebApi.Application.SearchService
{
    public class SearchServiceRequestHandler : IRequestHandler<SearchServiceRequest, SearchServiceResponse>
    {
        private readonly IMapper mapper;
        private readonly IRepository<Service> serviceRepo;

        public SearchServiceRequestHandler(
            IMapper mapper,
            IRepository<Service> serviceRepo)
        {
            this.mapper = mapper;
            this.serviceRepo = serviceRepo;
        }
        public Task<SearchServiceResponse> Handle(SearchServiceRequest request, CancellationToken cancellationToken)
        {
            var services = serviceRepo.Query().Where(a => a.Name.Contains(request.ServiceNameSnippet)).Skip(request.Pagination.Skip).Take(request.Pagination.Limit);
            if (!services.Any())
                throw new NotFoundException("No services match your search.");

            return Task.FromResult(new SearchServiceResponse { ResponseModels = mapper.ProjectTo<ServiceResponseModel>(services).AsEnumerable() });
        }
    }
}
