using Microsoft.AspNetCore.Authorization;
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
        /// <param name="nameSnippet">Snippet or whole of service name.</param>
        /// <param name="page">Page number.</param>
        /// <param name="limit">Page items limit.</param>
        /// <returns>List of matched services.</returns>
        [MapToApiVersion("1.0")]
        [HttpGet("search")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ServiceModel>))]
        public async Task<List<ServiceModel>> Search([FromQuery] string nameSnippet, [FromQuery] int page, [FromQuery] int limit)
        {
            var response = await Mediator.Send(new SearchServiceRequest
            {
                ServiceNameSnippet = nameSnippet,
                Pagination = new PaginationModel(page, limit)
            });
            return response.Services;
        }

        /// <summary>
        /// Get list of services, and can be paged.
        /// </summary>
        /// <param name="page">Page number.</param>
        /// <param name="limit">Page items limit.</param>
        /// <returns>List of services, as determined by pagination.</returns>
        [MapToApiVersion("1.0")]
        [HttpGet("")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ServiceModel>))]
        public async Task<List<ServiceModel>> Get([FromQuery] int page, [FromQuery] int limit)
        {
            var response = await Mediator.Send(new GetServicesRequest { Pagination = new PaginationModel(page, limit) });
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
        public async Task<ServiceModel> ActivateBonus([FromBody] ActivateBonusBinderModel binderModel)
        {
            var response = await Mediator.Send(new ActivateBonusRequest { BinderModel = binderModel });
            return response.Service;
        }
    }
}
