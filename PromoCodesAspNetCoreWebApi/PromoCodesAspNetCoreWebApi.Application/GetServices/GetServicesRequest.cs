using MediatR;
using PromoCodesAspNetCoreWebApi.Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PromoCodesAspNetCoreWebApi.Application.GetServices
{
    public class GetServicesRequest: IRequest<GetServicesResponse>
    {
        public PaginationModel Pagination { get; set; }
    }
}
