using PromoCodesAspNetCoreWebApi.Application.Common.Models;
using System.Collections.Generic;

namespace PromoCodesAspNetCoreWebApi.Application.SearchService
{
    public class SearchServiceResponse
    {
        public ServiceModel ServiceModel { get; set; }
        //public List<ServiceModel> Services { get; set; }
        public IEnumerable<ServiceModel> Services { get; set; }
    }
}