using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyLearnHub.Core.DTO
{
    public class ExamsBySection
    {
        public decimal Examid { get; set; }
        public decimal? Sectionid { get; set; }
        public string Examtype { get; set; } = null!;
        public DateTime Examdate { get; set; }
        public decimal Exammark { get; set; }
        public bool? Examstatus { get; set; }

        public decimal Examsolutionmark { get; set; }

        public DateTime? Openat { get; set; }
        public DateTime? Closeat { get; set; }
    }
}
