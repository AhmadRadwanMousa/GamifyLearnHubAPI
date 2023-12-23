using System;
using System.Collections.Generic;

namespace GamifyLearnHub.Data
{
    public partial class Coupon
    {
        public Coupon()
        {
            Usercoupons = new HashSet<Usercoupon>();
        }

        public decimal Couponid { get; set; }
        public string Couponname { get; set; } = null!;
        public decimal Couponpercent { get; set; }
        public decimal Points { get; set; }

        public virtual ICollection<Usercoupon> Usercoupons { get; set; }
    }
}
