using System;
using System.Collections.Generic;

namespace GamifyLearnHub.Data
{
    public partial class Coursesection
    {
        public Coursesection()
        {
            Lectures = new HashSet<Lecture>();
        }

        public decimal Coursesectionid { get; set; }
        public string Coursesectionname { get; set; } = null!;
        public decimal Coursesectionduration { get; set; }
        public decimal? Sectionid { get; set; }

        public virtual Section? Section { get; set; }
        public virtual ICollection<Lecture> Lectures { get; set; }
    }
}
