using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyLearnHub.Core.DTO
{
    public class AdminDetails
    {
        public int Adminscount { get; set; }
        public int Instructorscount { get; set; }
        public int Learnercount { get; set; }
        public int Instructorsrequests { get; set; }
        public int Couponscount { get; set; }

        public int Planscount { get; set; }
        public int Programscount { get; set; }
        public int Coursescount { get; set; }

        public int Paymentscount { get; set; }

    }
}
