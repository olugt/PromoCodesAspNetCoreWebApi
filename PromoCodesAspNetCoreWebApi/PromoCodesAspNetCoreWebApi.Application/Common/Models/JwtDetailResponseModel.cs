using AutoMapper;
using PromoCodesAspNetCoreWebApi.Application.Common.Mappings;
using PromoCodesAspNetCoreWebApi.Application.Common.Models.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace PromoCodesAspNetCoreWebApi.Application.Common.Models
{
    public class JwtDetailResponseModel : IMapFrom<JwtDetail>
    {
        public string Jwt { get; }
        public DateTime ExpiryDatetimeUtc { get; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<JwtDetail, JwtDetailResponseModel>();
        }
    }
}
