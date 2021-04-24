using AutoMapper;
using PromoCodesAspNetCoreWebApi.Application.Common.Mappings;
using PromoCodesAspNetCoreWebApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PromoCodesAspNetCoreWebApi.Application.Common.Models
{
    public class ServiceResponseModel : IMapFrom<Service>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Service, ServiceResponseModel>()
                .ForMember(a => a.Id, b => b.MapFrom(c => c.ServiceId))
                .ForMember(a => a.Name, b => b.MapFrom(c => c.Name));
        }
    }
}
