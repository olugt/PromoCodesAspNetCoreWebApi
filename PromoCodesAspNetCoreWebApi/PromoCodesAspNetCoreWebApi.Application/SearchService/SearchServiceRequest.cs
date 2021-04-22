using MediatR;
using PromoCodesAspNetCoreWebApi.Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PromoCodesAspNetCoreWebApi.Application.SearchService
{
    public class SearchServiceRequest: IRequest<SearchServiceResponse>
    {
        public SearchServiceBinderModel BinderModel { get; set; }
    }
}
