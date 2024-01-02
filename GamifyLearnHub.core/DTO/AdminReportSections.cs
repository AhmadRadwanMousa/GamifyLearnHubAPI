using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyLearnHub.Core.DTO
{
    public class AdminReportSections
    {
        public decimal Sectionid { get; set; }
        public string? Sectionname { get; set; }
        public int Sectionsize { get; set; }
        public string Firsname { get; set; } = null!;
        public string Lastname { get; set; } = null!;
        public string Coursename { get; set; } = null!;
        public int numberOfStudents { get; set; }
        public int numberOfExams { get; set; }
        public int numberOfAssignments { get; set; }
    }
}
