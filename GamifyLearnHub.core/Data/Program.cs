using System;
using System.Collections.Generic;

namespace GamifyLearnHub.Core.Data
{
    public partial class Program
    {
        public Program()
        {
            Cartitems = new HashSet<Cartitem>();
            Coursesequences = new HashSet<Coursesequence>();
        }

        public decimal Programid { get; set; }
        public string Programname { get; set; } = null!;
        public string? Programdescription { get; set; }
        public decimal? Planid { get; set; }
        public string? Programsyllabus { get; set; }
        public decimal? Educationalperiodid { get; set; }
        public decimal? Programprice { get; set; }
        public decimal? Programsale { get; set; }
        public string? Programimage { get; set; }

        public virtual Educationalperiod? Educationalperiod { get; set; }
        public virtual Plan? Plan { get; set; }
        public virtual ICollection<Cartitem> Cartitems { get; set; }
        public virtual ICollection<Coursesequence> Coursesequences { get; set; }
    }
}
