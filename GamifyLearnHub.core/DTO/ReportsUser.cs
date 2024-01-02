using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyLearnHub.Core.DTO
{
    public class ReportsUser
    {
        public string Coursename { get; set; } = null!;
        public decimal? Studentmark { get; set; }
        public decimal? Attendenceid { get; set; }

        public decimal attendance_count { get; set; }

        public decimal total_points { get; set; }

    }
}
