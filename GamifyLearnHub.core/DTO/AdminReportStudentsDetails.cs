using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyLearnHub.Core.DTO
{
    public class AdminReportStudentsDetails
    {
        public decimal Sectionid { get; set; }
        public string? Sectionname { get; set; }
        public decimal Userid { get; set; }
        public int absences { get; set; }
        public decimal total_section_exam_marks { get; set; }
        public decimal total_section_assignment_marks { get; set; }

    }
}
