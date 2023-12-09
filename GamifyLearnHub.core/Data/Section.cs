using System;
using System.Collections.Generic;

namespace GamifyLearnHub.Core.Data
{
    public partial class Section
    {
        public Section()
        {
            Assignments = new HashSet<Assignment>();
            Attendences = new HashSet<Attendence>();
            Exams = new HashSet<Exam>();
            Sectionannoncments = new HashSet<Sectionannoncment>();
            Usersections = new HashSet<Usersection>();
        }

        public decimal Sectionid { get; set; }
        public string? Sectionname { get; set; }
        public decimal? Userid { get; set; }
        public decimal Sectionsize { get; set; }
        public decimal? Coursesequenceid { get; set; }

        public virtual Coursesequence? Coursesequence { get; set; }
        public virtual User? User { get; set; }
        public virtual ICollection<Assignment> Assignments { get; set; }
        public virtual ICollection<Attendence> Attendences { get; set; }
        public virtual ICollection<Exam> Exams { get; set; }
        public virtual ICollection<Sectionannoncment> Sectionannoncments { get; set; }
        public virtual ICollection<Usersection> Usersections { get; set; }
    }
}
