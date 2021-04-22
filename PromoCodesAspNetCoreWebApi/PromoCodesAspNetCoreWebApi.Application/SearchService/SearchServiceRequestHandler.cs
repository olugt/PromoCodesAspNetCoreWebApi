using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PromoCodesAspNetCoreWebApi.Application.SearchService
{
    public class SearchServiceRequestHandler : IRequestHandler<SearchServiceRequest, SearchServiceResponse>
    {
        public SearchServiceRequestHandler()
        {

        }
        public Task<SearchServiceResponse> Handle(SearchServiceRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
