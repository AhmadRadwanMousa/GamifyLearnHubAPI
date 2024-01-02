using System;
using System.Collections.Generic;

namespace GamifyLearnHub.Data
{
    public partial class Sectionannoncment
    {
        public decimal Sectionannoncmentid { get; set; }
        public decimal? Sectionid { get; set; }
        public string? Annoncmentmessage { get; set; }
        public DateTime? Annoncmentdate { get; set; }

        public virtual Section? Section { get; set; }
    }
}
