using System;
using System.Collections.Generic;
using System.Text;

namespace PromoCodesAspNetCoreWebApi.Application.Common.Models
{
    /// <summary>
    /// Pagination information.
    /// </summary>
    public class PaginationBinderModel
    {
        /// <summary>
        /// The page number.
        /// </summary>
        public int Page { get; set; }
        /// <summary>
        /// The page items limit.
        /// </summary>
        public int Limit { get; set; }
        /// <summary>
        /// Number of items to skip at source before taking the number of items that's equal to Limit.
        /// </summary>
        public int Skip
        {
            get
            {
                return Limit * (Page - 1);
            }
        }
    }
}
