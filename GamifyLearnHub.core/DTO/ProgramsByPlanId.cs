using GamifyLearnHub.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyLearnHub.Core.DTO
{
    public class ProgramsByPlanId
    {
        public int ProgramId { get; set; }
        public string ProgramName { get; set; }
        public string ProgramDescription { get; set; }
        public int PlanId { get; set; }
        public string ProgramSyllabus { get; set; }
        public int EducationalPeriodId { get; set; }
        public DateTime EducationalPeriodStartDate { get; set; } 
        public DateTime EducationalPeriodEndDate { get; set; }
        public decimal ProgramPrice { get; set; }
        public decimal ProgramSale { get; set; }
        public string ProgramImage { get; set; }
        public int NumberOfUsers { get; set; }
        public int NumberOfCourses { get; set; }


    }
}
