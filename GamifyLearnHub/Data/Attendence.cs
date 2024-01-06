using System;
using System.Collections.Generic;

namespace GamifyLearnHub.Data
{
    public partial class Attendence
    {
        public Attendence()
        {
            Attendencedetails = new HashSet<Attendencedetail>();
        }

        public decimal Attendenceid { get; set; }
        public decimal? Sectionid { get; set; }
        public DateTime? Attenddate { get; set; }

        public virtual Section? Section { get; set; }
        public virtual ICollection<Attendencedetail> Attendencedetails { get; set; }
    }
}
