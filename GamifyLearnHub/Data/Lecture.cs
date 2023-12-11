using System;
using System.Collections.Generic;

namespace GamifyLearnHub.Data
{
    public partial class Lecture
    {
        public Lecture()
        {
            Userprogresses = new HashSet<Userprogress>();
        }

        public decimal Lectureid { get; set; }
        public decimal? Coursesectionid { get; set; }
        public string Lecturename { get; set; } = null!;
        public string Lecturefile { get; set; } = null!;
        public decimal Lectureduration { get; set; }

        public virtual Coursesection? Coursesection { get; set; }
        public virtual ICollection<Userprogress> Userprogresses { get; set; }
    }
}
