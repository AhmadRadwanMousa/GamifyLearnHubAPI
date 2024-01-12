using System;
using System.Collections.Generic;

namespace GamifyLearnHub.Data
{
    public partial class Announcement
    {
        public decimal Announcementid { get; set; }
        public string? Declaration { get; set; }
        public decimal? Sectionid { get; set; }

        public virtual Section? Section { get; set; }
    }
}
