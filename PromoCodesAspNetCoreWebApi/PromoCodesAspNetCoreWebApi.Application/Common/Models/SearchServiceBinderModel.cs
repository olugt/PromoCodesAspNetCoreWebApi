using System;
using System.Collections.Generic;
using System.Text;

namespace PromoCodesAspNetCoreWebApi.Application.Common.Models
{
    public class SearchServiceBinderModel
    {
        /// <summary>
        /// Snippet of service name.
        /// </summary>
        public string ServiceNameSnippet { get; set; }
        public PaginationBinderModel Pagination { get; set; }
    }
}
