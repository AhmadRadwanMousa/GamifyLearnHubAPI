using System;
using System.Collections.Generic;

namespace GamifyLearnHub.Data
{
    public partial class Exam
    {
        public Exam()
        {
            Examsolutiondetails = new HashSet<Examsolutiondetail>();
            Questions = new HashSet<Question>();
        }

        public decimal Examid { get; set; }
        public decimal? Sectionid { get; set; }
        public string Examtype { get; set; } = null!;
        public DateTime Examdate { get; set; }
        public decimal Exammark { get; set; }
        public bool? Examstatus { get; set; }
        public DateTime? Openat { get; set; }
        public DateTime? Closeat { get; set; }

        public virtual Section? Section { get; set; }
        public virtual ICollection<Examsolutiondetail> Examsolutiondetails { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
    }
}
