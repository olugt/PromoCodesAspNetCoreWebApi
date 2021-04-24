using PromoCodesAspNetCoreWebApi.Application.Common.Models;
using System.Collections.Generic;

namespace PromoCodesAspNetCoreWebApi.Application.SearchService
{
    public class SearchServiceResponse
    {
        public IEnumerable<ServiceResponseModel> ResponseModels { get; set; }
    }
}