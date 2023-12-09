using System;
using System.Collections.Generic;

namespace GamifyLearnHub.Core.Data
{
    public partial class Attendencedetail
    {
        public decimal Attendencedetailsid { get; set; }
        public decimal? Userid { get; set; }
        public bool? Isattended { get; set; }
        public decimal? Attendenceid { get; set; }

        public virtual Attendence? Attendence { get; set; }
        public virtual User? User { get; set; }
    }
}
