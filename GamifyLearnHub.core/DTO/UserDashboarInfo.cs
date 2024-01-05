using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyLearnHub.Core.DTO
{
    public class UserDashboarInfo
    {
        public decimal Userid { get; set; }
        public decimal? Totalpoints { get; set; }
        public decimal? Total_Badges { get; set; }
        public decimal? Total_Certificates { get; set; }
        public decimal? Total_Programs { get; set; }
        public decimal? Total_Testimonials { get; set; }

    }
}
