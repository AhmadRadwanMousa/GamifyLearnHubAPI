using System;
using System.Collections.Generic;

namespace GamifyLearnHub.Core.Data
{
    public partial class Instructordetail
    {
        public decimal Instructorid { get; set; }
        public decimal? Userid { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public string? Facebooklink { get; set; }
        public string? Instagramlink { get; set; }
        public string? Linkedinlink { get; set; }
        public string? Twitterlink { get; set; }
        public string? Experience { get; set; }

        public virtual User? User { get; set; }
    }
}
