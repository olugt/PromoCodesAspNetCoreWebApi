using PromoCodesAspNetCoreWebApi.Application.Common.Interfaces.Infrastructure;
using PromoCodesAspNetCoreWebApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PromoCodesAspNetCoreWebApi.Application.Common.Logic
{
    public static class UserLogic
    {
        public static User GetUserByEmailAddress(string emailAddress, IRepository<User> userRepo)
        {
            return userRepo.Query().Where(a => a.EmailAddress == emailAddress).Single();
        }
    }
}
