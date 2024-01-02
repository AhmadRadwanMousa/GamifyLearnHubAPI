using System;
using System.Collections.Generic;

namespace GamifyLearnHub.Data
{
    public partial class Cartitem
    {
        public decimal Cartitemsid { get; set; }
        public decimal? Cartid { get; set; }
        public decimal? Programid { get; set; }
        public decimal? Sectionid { get; set; }

        public virtual Cart? Cart { get; set; }
        public virtual Program? Program { get; set; }
        public virtual Section? Section { get; set; }
    }
}
