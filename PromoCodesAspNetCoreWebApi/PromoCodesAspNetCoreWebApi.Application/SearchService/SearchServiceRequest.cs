using MediatR;
using PromoCodesAspNetCoreWebApi.Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PromoCodesAspNetCoreWebApi.Application.SearchService
{
    public class SearchServiceRequest: IRequest<SearchServiceResponse>
    {
        /// <summary>
        /// Snippet of service name.
        /// </summary>
        public string ServiceNameSnippet { get; set; }
        public PaginationModel Pagination { get; set; }
    }
}
