using System;
using System.Collections.Generic;

namespace GamifyLearnHub.Data
{
    public partial class Educationalperiod
    {
        public Educationalperiod()
        {
            Programs = new HashSet<Program>();
        }

        public decimal Educationalperiodid { get; set; }
        public DateTime Startdate { get; set; }
        public DateTime Enddate { get; set; }

        public virtual ICollection<Program> Programs { get; set; }
    }
}
