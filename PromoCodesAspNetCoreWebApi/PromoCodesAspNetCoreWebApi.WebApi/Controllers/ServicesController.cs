using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PromoCodesAspNetCoreWebApi.Application.ActivateBonus;
using PromoCodesAspNetCoreWebApi.Application.Common.Models;
using PromoCodesAspNetCoreWebApi.Application.GetServices;
using PromoCodesAspNetCoreWebApi.Application.SearchService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PromoCodesAspNetCoreWebApi.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : BaseController
    {
        /// <summary>
        /// Search for a service with a service name snippet.
        /// </summary>
        /// <param name="binderModel">Information about the service.</param>
        /// <returns>All matched services are returned.</returns>
        [MapToApiVersion("1.0")]
        [HttpGet("search")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ServiceModel>))]
        public async Task<List<ServiceModel>> Search(SearchServiceBinderModel binderModel)
        {
            var response = await Mediator.Send(new SearchServiceRequest { BinderModel = binderModel });
            return response.Services;
        }

        /// <summary>
        /// Get list of services, and can be paged.
        /// </summary>
        /// <param name="paginationModel">Pagination information.</param>
        /// <returns>List of services, as determined by pagination.</returns>
        [MapToApiVersion("1.0")]
        [HttpGet("")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ServiceModel>))]
        public async Task<List<ServiceModel>> Get(PaginationBinderModel binderModel)
        {
            var response = await Mediator.Send(new GetServicesRequest { Pagination = binderModel });
            return response.Services;
        }

        /// <summary>
        /// Activate bonus for the identified service, for the current user.
        /// </summary>
        /// <param name="binderModel">Information about the service.</param>
        /// <returns>The service about which bonus was activated for the user.</returns>
        [MapToApiVersion("1.0")]
        [HttpPost("activate-bonus")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ServiceModel))]
        public async Task<ServiceModel> ActivateBonus(ActivateBonusBinderModel binderModel)
        {
            var response = await Mediator.Send(new ActivateBonusRequest { BinderModel = binderModel });
            return response.Service;
        }
    }
}
