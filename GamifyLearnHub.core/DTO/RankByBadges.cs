using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyLearnHub.Core.DTO
{
    public class RankByBadges
    {
        public decimal ranking { get; set; }
        public decimal? Total_Badges { get; set; }
        public decimal Userid { get; set; }
        public string Firsname { get; set; } = null!;
        public string Lastname { get; set; } = null!;
        public string? Userimage { get; set; }
    }
}
