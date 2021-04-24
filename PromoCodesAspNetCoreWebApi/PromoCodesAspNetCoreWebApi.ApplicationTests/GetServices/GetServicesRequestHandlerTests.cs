using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PromoCodesAspNetCoreWebApi.Application.Common.Interfaces.Infrastructure;
using PromoCodesAspNetCoreWebApi.Application.Common.Models;
using PromoCodesAspNetCoreWebApi.Application.GetServices;
using PromoCodesAspNetCoreWebApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PromoCodesAspNetCoreWebApi.Application.GetServices.Tests
{
    [TestClass()]
    public class GetServicesRequestHandlerTests
    {
        IMapper mapper;
        Mock<IRepository<Service>> mockServiceRepo;

        public GetServicesRequestHandlerTests()
        {
            var services = new List<Service>()
            {
                new Service {
                    ServiceId = 1,
                    Name = "Some service name"
                },
                new Service {
                    ServiceId = 2,
                    Name = "Some other service name"
                },
                new Service {
                    ServiceId = 3,
                    Name = "Just some other service name"
                },
                new Service {
                    ServiceId = 4,
                    Name = "And another service name"
                },
                new Service {
                    ServiceId = 5,
                    Name = "Also another service name"
                }
            };

            //
            var config = new MapperConfiguration(exp => exp.CreateMap<Service, ServiceResponseModel>()
            .ForMember(a => a.Id, b => b.MapFrom(c => c.ServiceId))
            .ForMember(a => a.Name, b => b.MapFrom(c => c.Name)));
            mapper = new Mapper(config);

            mockServiceRepo = new Mock<IRepository<Service>>();
            mockServiceRepo.Setup(a => a.Query()).Returns(services.AsQueryable());
        }

        [DataTestMethod()]
        [DataRow(2, 2)]
        public async Task HandleTest(int page, int limit)
        {
            var request = new GetServicesRequest { Pagination = new PaginationModel(page, limit) };
            var cancellationToken = CancellationToken.None;

            //

            var getServicesResponse = await new GetServicesRequestHandler(mapper, mockServiceRepo.Object).Handle(request, cancellationToken);

            //

            //Assert.AreEqual(2, getServicesResponse.Services.Count);
            Assert.AreEqual(2, getServicesResponse.ResponseModels.Count());
        }
    }
}