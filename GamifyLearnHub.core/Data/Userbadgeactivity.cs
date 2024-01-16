using System;
using System.Collections.Generic;

namespace GamifyLearnHub.Core.Data
{
    public partial class Userbadgeactivity
    {
        public decimal? Userid { get; set; }
        public decimal? Badgeactivityid { get; set; }
        public DateTime? Dateearned { get; set; }
        public decimal Userbadgeactivityid { get; set; }
        public bool? Isviewed { get; set; }

        public virtual Badgeactivity? Badgeactivity { get; set; }
        public virtual User? User { get; set; }
    }
}
