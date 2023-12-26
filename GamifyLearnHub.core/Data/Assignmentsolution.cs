using System;
using System.Collections.Generic;

namespace GamifyLearnHub.Core.Data
{
    public partial class Assignmentsolution
    {
        public decimal Assignmentsolutionid { get; set; }
        public decimal? Assignmentid { get; set; }
        public decimal? Userid { get; set; }
        public string? Assignmentsolutionvalue { get; set; }
        public decimal? Assignmentsolutionmark { get; set; }
        public DateTime? Submittedat { get; set; }

        public virtual Assignment? Assignment { get; set; }
        public virtual User? User { get; set; }
    }
}
