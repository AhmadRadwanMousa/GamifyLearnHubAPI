using System;
using System.Collections.Generic;

namespace GamifyLearnHub.Data
{
    public partial class Badgeactivity
    {
        public Badgeactivity()
        {
            Userbadgeactivities = new HashSet<Userbadgeactivity>();
        }

        public decimal Badgeactivityid { get; set; }
        public string Badgeimage { get; set; } = null!;
        public decimal Badgepoints { get; set; }
        public string? Badgename { get; set; }

        public virtual ICollection<Userbadgeactivity> Userbadgeactivities { get; set; }
    }
}
