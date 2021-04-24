using AutoMapper;
using MediatR;
using PromoCodesAspNetCoreWebApi.Application.Common.Constants;
using PromoCodesAspNetCoreWebApi.Application.Common.Interfaces.Infrastructure;
using PromoCodesAspNetCoreWebApi.Application.Common.Logic;
using PromoCodesAspNetCoreWebApi.Application.Common.Models;
using PromoCodesAspNetCoreWebApi.Common.Exceptions;
using PromoCodesAspNetCoreWebApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PromoCodesAspNetCoreWebApi.Application.Login
{
    public class LoginRequestHandler : IRequestHandler<LoginRequest, LoginResponse>
    {
        private readonly IMapper mapper;
        private readonly IRepository<User> userRepo;
        private readonly IJwtManager jwtManager;

        public LoginRequestHandler(
            IMapper mapper,
            IRepository<User> userRepo,
            IJwtManager jwtManager)
        {
            this.mapper = mapper;
            this.userRepo = userRepo;
            this.jwtManager = jwtManager;
        }

        public async Task<LoginResponse> Handle(LoginRequest request, CancellationToken cancellationToken)
        {
            var user = userRepo.Query().Where(a => a.EmailAddress == request.RequestModel.EmailAddress).SingleOrDefault();

            if (user == null)
                throw new NotFoundException("User not found.");

            if (user.PasswordHashToBase64 != CryptographyLogic.HashStringToSha256ToBase64(request.RequestModel.Password))
                throw new IdentityException("Invalid credentials!");

            var jwtDetail = await jwtManager.GenerateJwtDetails(new List<Claim>() { new Claim(CustomClaimTypeConstants.EmailAddress, user.EmailAddress) });
            return new LoginResponse
            {
                ResponseModel = new JwtDetailResponseModel
                {
                   JwtDetail = jwtDetail
                }
            };
        }
    }
}
