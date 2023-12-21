using System;
using System.Collections.Generic;

namespace GamifyLearnHub.Data
{
    public partial class Assignmentsolutiondetail
    {
        public decimal Assignmentsolutiondetailsid { get; set; }
        public decimal? Userid { get; set; }
        public decimal? Assignmentid { get; set; }
        public decimal Assignmentsolutionmark { get; set; }

        public virtual Assignment? Assignment { get; set; }
        public virtual User? User { get; set; }
    }
}
