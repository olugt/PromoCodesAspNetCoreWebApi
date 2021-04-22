using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PromoCodesAspNetCoreWebApi.Application.ActivateBonus;
using PromoCodesAspNetCoreWebApi.Application.Common.Interfaces.Infrastructure;
using PromoCodesAspNetCoreWebApi.Application.Common.Models;
using PromoCodesAspNetCoreWebApi.Common.Exceptions;
using PromoCodesAspNetCoreWebApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PromoCodesAspNetCoreWebApi.Application.ActivateBonus.Tests
{
    [TestClass()]
    public class ActivateBonusRequestHandlerTests
    {
        const int serviceId1 = 1;
        const int serviceId2 = 2;

        const int userId1 = 1;
        const string userEmailAddress1 = "example1@example.com";
        const int userId2 = 2;
        const string userEmailAddress2 = "example2@example.com";

        const string promoCode1 = "promo-code-1";
        const string promoCode2 = "promo-code-2";

        Mock<IMapper> mockMapper;
        Mock<IRepository<Bonus>> mockBonusRepo;
        Mock<IRepository<User>> mockUserRepo;
        Mock<IRepository<PromoCode>> mockPromoCodeRepo;

        public ActivateBonusRequestHandlerTests()
        {
            var bonuses = new List<Bonus>()
            {
                new Bonus {
                    IsActivated = false,
                    UserId = userId1,
                    User = new User
                    {
                        UserId = userId1,
                        EmailAddress = userEmailAddress1
                    },
                    ServiceId = serviceId1,
                    Service = new Service
                    {
                        ServiceId = serviceId1,
                        Name = "Example name."
                    }
                },
                new Bonus {
                    IsActivated = false,
                    UserId = userId2,
                    User = new User
                    {
                        UserId = userId2,
                        EmailAddress = userEmailAddress2
                    },
                    ServiceId = serviceId2,
                    Service = new Service
                    {
                        ServiceId = serviceId2,
                        Name = "Another example name."
                    }
                }
            };

            var users = new List<User>()
            {
                new User {
                    UserId = userId1,
                    EmailAddress = userEmailAddress1
                },
                new User {
                    UserId = userId2,
                    EmailAddress = userEmailAddress2
                }
            };

            var promoCodes = new List<PromoCode>()
            {
                new PromoCode {
                    PromoCodeId = 1,
                    Name = promoCode1
                },
                new PromoCode {
                    PromoCodeId = 2,
                    Name = promoCode2
                }
            };

            //

            mockMapper = new Mock<IMapper>();
            mockMapper.Setup(a => a.Map<ServiceModel>(It.IsAny<Service>())).Returns((Service b) => new ServiceModel { Id = b.ServiceId, Name = b.Name });

            mockBonusRepo = new Mock<IRepository<Bonus>>();
            mockBonusRepo.Setup(a => a.Query()).Returns(bonuses.AsQueryable());
            mockBonusRepo.Setup(a => a.UpdateAsync(It.IsAny<Bonus>(), It.IsAny<CancellationToken>())).Returns(Task.FromResult(1));

            mockUserRepo = new Mock<IRepository<User>>();
            mockUserRepo.Setup(a => a.Query()).Returns(users.AsQueryable());

            mockPromoCodeRepo = new Mock<IRepository<PromoCode>>();
            mockPromoCodeRepo.Setup(a => a.Query()).Returns(promoCodes.AsQueryable());
        }

        [DataTestMethod()]
        [DataRow(serviceId1, userEmailAddress1)]
        [DataRow(serviceId2, userEmailAddress2)]
        public async Task HandleTest(int serviceId, string userEmailAddress)
        {
            var request = new ActivateBonusRequest { BinderModel = new ActivateBonusBinderModel { ServiceId = serviceId } };
            var cancellationToken = CancellationToken.None;
            var mockCurrentUser = new Mock<ICurrentUser>();
            mockCurrentUser.Setup(a => a.GetEmailAddress()).Returns(userEmailAddress);

            //

            var activateBonusResponse = await new ActivateBonusRequestHandler(mockMapper.Object, mockCurrentUser.Object, mockBonusRepo.Object, mockUserRepo.Object, mockPromoCodeRepo.Object).Handle(request, cancellationToken);

            //

            Assert.AreEqual(serviceId, activateBonusResponse.Service.Id);
        }

        [DataTestMethod()]
        [DataRow(serviceId1, userEmailAddress1, "wrong-promo-code")]
        public void Handle_WithWrongPromoCode_Test(int serviceId, string userEmailAddress, string promoCode)
        {
            var request = new ActivateBonusRequest { BinderModel = new ActivateBonusBinderModel { ServiceId = serviceId, PromoCode = promoCode } };
            var cancellationToken = CancellationToken.None;
            var mockCurrentUser = new Mock<ICurrentUser>();
            mockCurrentUser.Setup(a => a.GetEmailAddress()).Returns(userEmailAddress);

            //

            var activateBonusRequestHandler = new ActivateBonusRequestHandler(mockMapper.Object, mockCurrentUser.Object, mockBonusRepo.Object, mockUserRepo.Object, mockPromoCodeRepo.Object);

            //

            Assert.ThrowsExceptionAsync<NotFoundException>(async () =>
            {
                await activateBonusRequestHandler.Handle(request, cancellationToken);
            });
        }
    }
}