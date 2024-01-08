using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyLearnHub.Core.DTO
{
    public class Top3BySectionId
    {
        public decimal Userid { get; set; }
        public string Firsname { get; set; } = null!;
        public string Lastname { get; set; } = null!;

        public decimal points_count { get; set; }
    }
}
