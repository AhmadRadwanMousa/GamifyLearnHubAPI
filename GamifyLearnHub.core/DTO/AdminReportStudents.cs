using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyLearnHub.Core.DTO
{
    public class AdminReportStudents
    {
        public decimal Userid { get; set; }
        public string Firsname { get; set; } = null!;
        public string Lastname { get; set; } = null!;
        public string? Userimage { get; set; }
        public decimal? Totalpoints { get; set; }
        public DateTime Dateofbirth { get; set; }

        public int completedcourses { get; set;}
    }
}
