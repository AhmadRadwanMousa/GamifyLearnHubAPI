using System;
using System.Collections.Generic;

namespace GamifyLearnHub.Core.Data
{
    public partial class Userprogress
    {
        public decimal Userprogessid { get; set; }
        public decimal? Userid { get; set; }
        public decimal? Lectureid { get; set; }
        public decimal? Sectionid { get; set; }

        public virtual Lecture? Lecture { get; set; }
        public virtual Section? Section { get; set; }
        public virtual User? User { get; set; }
    }
}
