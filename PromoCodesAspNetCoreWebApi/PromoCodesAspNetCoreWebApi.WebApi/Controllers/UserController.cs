﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PromoCodesAspNetCoreWebApi.Application.Common.Models;
using PromoCodesAspNetCoreWebApi.Application.Common.Models.Infrastructure;
using PromoCodesAspNetCoreWebApi.Application.Login;
using PromoCodesAspNetCoreWebApi.Application.RegisterUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PromoCodesAspNetCoreWebApi.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        /// <summary>
        /// Registers a user with the email address and password provided.
        /// </summary>
        /// <param name="binderModel">User credentials.</param>
        /// <returns>Returns email address of the newly registered user.</returns>
        [AllowAnonymous]
        [MapToApiVersion("1.0")]
        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        public async Task<string> Register([FromBody] RegisterBinderModel binderModel)
        {
            var response = await Mediator.Send(new RegisterUserRequest { BinderModel = binderModel });
            return response.EmailAddress;
        }

        /// <summary>
        /// Logs in a user with the email address and password provided.
        /// </summary>
        /// <param name="binderModel">User credentials.</param>
        /// <returns>Returns the JWT detail generated for the suer.</returns>
        [AllowAnonymous]
        [MapToApiVersion("1.0")]
        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(JwtDetail))]
        public async Task<JwtDetail> Login([FromBody] LoginBinderModel binderModel)
        {
            var response = await Mediator.Send(new LoginRequest { BinderModel = binderModel });
            return response.JwtDetail;
        }
    }
}
