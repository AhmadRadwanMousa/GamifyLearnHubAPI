using System;
using System.Collections.Generic;

namespace GamifyLearnHub.Core.Data
{
    public partial class Assignment
    {
        public Assignment()
        {
            Assignmentsolutiondetails = new HashSet<Assignmentsolutiondetail>();
            Assignmentsolutions = new HashSet<Assignmentsolution>();
        }

        public decimal Assignmentid { get; set; }
        public string? Assignmentname { get; set; }
        public string? Assignmentdescription { get; set; }
        public decimal Assignmentmark { get; set; }
        public DateTime? Assignmentdeadline { get; set; }
        public decimal? Sectionid { get; set; }

        public virtual Section? Section { get; set; }
        public virtual ICollection<Assignmentsolutiondetail> Assignmentsolutiondetails { get; set; }
        public virtual ICollection<Assignmentsolution> Assignmentsolutions { get; set; }
    }
}
