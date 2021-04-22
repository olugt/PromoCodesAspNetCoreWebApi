using PromoCodesAspNetCoreWebApi.Application.Common.Models;
using System.Collections.Generic;

namespace PromoCodesAspNetCoreWebApi.Application.GetServices
{
    public class GetServicesResponse
    {
        public List<ServiceModel> Services { get; set; }
    }
}