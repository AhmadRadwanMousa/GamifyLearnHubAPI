using System;
using System.Collections.Generic;

namespace GamifyLearnHub.Core.Data
{
    public partial class Educationalperiod
    {
        public Educationalperiod()
        {
            Coursesequences = new HashSet<Coursesequence>();
            Programs = new HashSet<Program>();
        }

        public decimal Educationalperiodid { get; set; }
        public DateTime Startdate { get; set; }
        public DateTime Enddate { get; set; }
        public DateTime? Startdatebystamp { get; set; }

        public virtual ICollection<Coursesequence> Coursesequences { get; set; }
        public virtual ICollection<Program> Programs { get; set; }
    }
}
