using System;
using System.Collections.Generic;
using System.Text;

namespace PromoCodesAspNetCoreWebApi.Domain.Entities
{
    public class Bonus
    {
        public int BonusId { get; set; }
        public decimal Amount { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int ServiceId { get; set; }
        public Service Service { get; set; }
    }
}
