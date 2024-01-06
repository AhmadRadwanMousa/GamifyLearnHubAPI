using System;
using System.Collections.Generic;

namespace GamifyLearnHub.Data
{
    public partial class Examsolutiondetail
    {
        public decimal Examsolutionmark { get; set; }
        public decimal? Examid { get; set; }
        public decimal? Userid { get; set; }
        public decimal Examsolutiondetailsid { get; set; }

        public virtual Exam? Exam { get; set; }
        public virtual User? User { get; set; }
    }
}
