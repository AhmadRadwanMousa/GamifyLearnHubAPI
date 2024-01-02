using System;
using System.Collections.Generic;

namespace GamifyLearnHub.Data
{
    public partial class Examsolution
    {
        public decimal Examsolutionid { get; set; }
        public decimal? Userid { get; set; }
        public decimal? Questionoptionid { get; set; }

        public virtual Questionoption? Questionoption { get; set; }
        public virtual User? User { get; set; }
    }
}
