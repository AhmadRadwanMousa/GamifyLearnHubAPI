using System;
using System.Collections.Generic;

namespace GamifyLearnHub.Data
{
    public partial class Pointsactivity
    {
        public Pointsactivity()
        {
            Userpointsactivities = new HashSet<Userpointsactivity>();
        }

        public decimal Pointsactivityid { get; set; }
        public string Pointsactivityname { get; set; } = null!;
        public decimal Points { get; set; }
        public decimal? Numberofcourses { get; set; }
        public decimal? Numberofdays { get; set; }

        public virtual ICollection<Userpointsactivity> Userpointsactivities { get; set; }
    }
}
