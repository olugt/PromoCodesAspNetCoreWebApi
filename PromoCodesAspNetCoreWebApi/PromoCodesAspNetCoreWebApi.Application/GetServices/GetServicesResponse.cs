using PromoCodesAspNetCoreWebApi.Application.Common.Models;
using System.Collections.Generic;

namespace PromoCodesAspNetCoreWebApi.Application.GetServices
{
    public class GetServicesResponse
    {
        public IEnumerable<ServiceResponseModel> ResponseModels { get; set; }
    }
}