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
        public decimal? Courseid { get; set; }
        public string Coursesectionname { get; set; } = null!;
        public decimal Coursesectionduration { get; set; }

        public virtual Course? Course { get; set; }
        public virtual ICollection<Lecture> Lectures { get; set; }
    }
}
