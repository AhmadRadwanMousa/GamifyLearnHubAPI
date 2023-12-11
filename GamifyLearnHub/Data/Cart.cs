using System;
using System.Collections.Generic;

namespace GamifyLearnHub.Data
{
    public partial class Cart
    {
        public Cart()
        {
            Cartitems = new HashSet<Cartitem>();
        }

        public decimal Cartid { get; set; }
        public decimal? Userid { get; set; }
        public decimal? Totalprice { get; set; }
        public string? Cartstatus { get; set; }
        public decimal? Paymentid { get; set; }

        public virtual Payment? Payment { get; set; }
        public virtual User? User { get; set; }
        public virtual ICollection<Cartitem> Cartitems { get; set; }
    }
}
