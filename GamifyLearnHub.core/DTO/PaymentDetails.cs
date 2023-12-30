using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyLearnHub.Core.DTO
{
    public class PaymentDetails
    {
        public decimal ?Paymentid { get; set; }
        public DateTime? Paymentdate { get; set; }
        public decimal? Userid { get; set; }
        public decimal Cartid { get; set; }
    }
}
