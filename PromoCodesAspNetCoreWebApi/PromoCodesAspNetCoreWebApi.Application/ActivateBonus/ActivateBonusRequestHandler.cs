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
    public class ActivateBonusRequestHandler : IRequestHandler<ActivateBonusRequest, ActivateBonusResponse>
    {
        private readonly IMapper mapper;
        private readonly ICurrentUser currentUser;
        private readonly IRepository<Bonus> bonusRepo;
        private readonly IRepository<User> userRepo;

        public ActivateBonusRequestHandler(
            IMapper mapper,
            ICurrentUser currentUser,
            IRepository<Bonus> bonusRepo,
            IRepository<User> userRepo)
        {
            this.mapper = mapper;
            this.currentUser = currentUser;
            this.bonusRepo = bonusRepo;
            this.userRepo = userRepo;
        }

        public async Task<ActivateBonusResponse> Handle(ActivateBonusRequest request, CancellationToken cancellationToken)
        {
            var user = UserLogic.GetUserByEmailAddress(currentUser.GetEmailAddress(), userRepo);

            var serviceId = request.BinderModel.ServiceId;

            var bonus = bonusRepo.Query().Where(a => a.UserId == user.UserId && a.ServiceId == serviceId).SingleOrDefault();

            if (bonus == null)
                throw new NotFoundException("The user is not subscribed to the service.");

            if (bonus is { IsActivated: true })
                throw new InvalidOperationException("Bonus already activated for the user.");

            bonus.IsActivated = true;
            if (await bonusRepo.UpdateAsync(bonus, cancellationToken) != 1)
                throw new NotFoundException("Bonus data could not be found.");

            return new ActivateBonusResponse { Service = mapper.Map<ServiceModel>(bonus.Service) };
        }
    }
}
