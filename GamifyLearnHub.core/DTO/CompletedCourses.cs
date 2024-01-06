using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyLearnHub.Core.DTO
{
    public class CompletedCourses
    {
        public decimal Certificationid { get; set; }
        public string? Certificationimage { get; set; }
        public string Coursename { get; set; } = null!;
    }
}
