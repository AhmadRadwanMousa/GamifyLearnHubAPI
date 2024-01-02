using System;
using System.Collections.Generic;

namespace GamifyLearnHub.Data
{
    public partial class Usercoupon
    {
        public decimal Usercouponid { get; set; }
        public decimal? Userid { get; set; }
        public decimal? Couponid { get; set; }
        public DateTime? Dateearned { get; set; }
        public bool? Isused { get; set; }

        public virtual Coupon? Coupon { get; set; }
        public virtual User? User { get; set; }
    }
}
