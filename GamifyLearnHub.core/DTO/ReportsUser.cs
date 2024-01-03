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
        public decimal? total_mark { get; set; }
        public decimal? Attendenceid { get; set; }

        public decimal absences { get; set; }

    }
}
