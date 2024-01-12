using System;
using System.Collections.Generic;

namespace GamifyLearnHub.Data
{
    public partial class Userpointsactivity
    {
        public decimal Userpointsactivityid { get; set; }
        public decimal? Userid { get; set; }
        public decimal? Pointsactivityid { get; set; }
        public DateTime? Dateearned { get; set; }
        public decimal? Usersectionid { get; set; }
        public bool? Isviewed { get; set; }

        public virtual Pointsactivity? Pointsactivity { get; set; }
        public virtual User? User { get; set; }
        public virtual Usersection? Usersection { get; set; }
    }
}
