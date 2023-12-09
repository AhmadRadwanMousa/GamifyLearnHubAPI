using System;
using System.Collections.Generic;

namespace GamifyLearnHub.Core.Data
{
    public partial class Questionoption
    {
        public Questionoption()
        {
            Examsolutions = new HashSet<Examsolution>();
        }

        public decimal Questionoptionid { get; set; }
        public decimal? Questionid { get; set; }
        public string Questionoptiondescription { get; set; } = null!;
        public bool? Iscorrect { get; set; }

        public virtual Question? Question { get; set; }
        public virtual ICollection<Examsolution> Examsolutions { get; set; }
    }
}
