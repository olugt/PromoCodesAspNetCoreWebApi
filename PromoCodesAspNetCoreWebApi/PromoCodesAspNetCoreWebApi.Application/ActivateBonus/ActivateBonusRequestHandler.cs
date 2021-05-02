using AutoMapper;
using MediatR;
using PromoCodesAspNetCoreWebApi.Application.Common.Interfaces;
using PromoCodesAspNetCoreWebApi.Application.Common.Interfaces.Infrastructure;
using PromoCodesAspNetCoreWebApi.Application.Common.Logic;
using PromoCodesAspNetCoreWebApi.Application.Common.Models;
using PromoCodesAspNetCoreWebApi.Common.Exceptions;
using PromoCodesAspNetCoreWebApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PromoCodesAspNetCoreWebApi.Application.ActivateBonus
{
    /// <summary>
    /// Handle creation of a new bonus, with respect to information from the user, service and the promo code used (if any).
    /// </summary>
    public class ActivateBonusRequestHandler : IRequestHandler<ActivateBonusRequest, ActivateBonusResponse>
    {
        private readonly IMapper mapper;
        private readonly ICurrentUser currentUser;
        private readonly IRepository<Bonus> bonusRepo;
        private readonly IRepository<User> userRepo;
        private readonly IRepository<PromoCode> promoCodeRepo;
        private readonly IRepository<Service> serviceRepo;

        public ActivateBonusRequestHandler(
            IMapper mapper,
            ICurrentUser currentUser,
            IRepository<Bonus> bonusRepo,
            IRepository<User> userRepo,
            IRepository<PromoCode> promoCodeRepo,
            IRepository<Service> serviceRepo)
        {
            this.mapper = mapper;
            this.currentUser = currentUser;
            this.bonusRepo = bonusRepo;
            this.userRepo = userRepo;
            this.promoCodeRepo = promoCodeRepo;
            this.serviceRepo = serviceRepo;
        }

        public async Task<ActivateBonusResponse> Handle(ActivateBonusRequest request, CancellationToken cancellationToken)
        {
            if (!string.IsNullOrEmpty(request.RequestModel.PromoCode) && !promoCodeRepo.Query().Any(a => a.Name == request.RequestModel.PromoCode))
                throw new NotFoundException("Promo code invalid.");

            var service = serviceRepo.ReadById(request.RequestModel.ServiceId);
            if (service == null)
                throw new NotFoundException("Service not found.");

            var user = UserLogic.GetUserByEmailAddress(currentUser.GetEmailAddress(), userRepo);

            var bonus = new Bonus();

            var promoCode = promoCodeRepo.Query().SingleOrDefault(a => a.Name == request.RequestModel.PromoCode);

            bonus.PromoCodeId = promoCode?.PromoCodeId;
            bonus.UserId = user.UserId;
            bonus.ServiceId = service.ServiceId;
            bonus.Amount = promoCode?.Amount;
            bonus.IsActivated = true;
            bonus.ActivationDateTimeOffset = DateTime.Now;
            
            if (await bonusRepo.CreateAsync(bonus, cancellationToken) != 1)
                throw new NotFoundException("Bonus data could not be found.");

            return new ActivateBonusResponse { ResponseModel = mapper.Map<ServiceResponseModel>(service) };
        }
    }
}
