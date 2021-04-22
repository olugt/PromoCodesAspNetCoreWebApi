using MediatR;
using PromoCodesAspNetCoreWebApi.Application.Common.Constants;
using PromoCodesAspNetCoreWebApi.Application.Common.Interfaces.Infrastructure;
using PromoCodesAspNetCoreWebApi.Application.Common.Logic;
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
        private readonly IRepository<User> userRepo;
        private readonly IJwtManager jwtManager;

        public LoginRequestHandler(
            IRepository<User> userRepo,
            IJwtManager jwtManager)
        {
            this.userRepo = userRepo;
            this.jwtManager = jwtManager;
        }

        public async Task<LoginResponse> Handle(LoginRequest request, CancellationToken cancellationToken)
        {
            var user = userRepo.Query().Where(a => a.EmailAddress == request.BinderModel.EmailAddress).SingleOrDefault();

            if (user == null)
                throw new NotFoundException("User not found.");

            if (user.PasswordHashToBase64 != CryptographyLogic.HashStringToSha256ToBase64(request.BinderModel.Password))
                throw new IdentityException("Invalid credentials!");

            return new LoginResponse { JwtDetail = await jwtManager.GenerateJwtDetails(new List<Claim>() { new Claim(CustomClaimTypeConstants.EmailAddress, user.EmailAddress) }) };
        }
    }
}
