using System;
using System.Collections.Generic;

namespace GamifyLearnHub.Data
{
    public partial class Payment
    {
        public Payment()
        {
            Carts = new HashSet<Cart>();
        }

        public decimal Paymentid { get; set; }
        public DateTime? Paymentdate { get; set; }
        public decimal? Userid { get; set; }

        public virtual User? User { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
    }
}
