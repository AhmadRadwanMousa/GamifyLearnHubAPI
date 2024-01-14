using System;
using System.Collections.Generic;

namespace GamifyLearnHub.Core.Data
{
    public partial class Userreview
    {
        public decimal Userreviewid { get; set; }
        public decimal? Userid { get; set; }
        public decimal? Programid { get; set; }
        public decimal? Reviewrate { get; set; }
        public string? Reviewcontent { get; set; }

        public virtual Program? Program { get; set; }
        public virtual User? User { get; set; }
    }
}
