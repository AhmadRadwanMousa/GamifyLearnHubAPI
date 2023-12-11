using System;
using System.Collections.Generic;

namespace GamifyLearnHub.Data
{
    public partial class Course
    {
        public Course()
        {
            Coursesections = new HashSet<Coursesection>();
            Coursesequences = new HashSet<Coursesequence>();
        }

        public decimal Courseid { get; set; }
        public string Courselevel { get; set; } = null!;
        public string Coursename { get; set; } = null!;
        public string Courseimage { get; set; } = null!;
        public decimal Examweight { get; set; }
        public decimal Assignmentweight { get; set; }
        public decimal Quizzezweight { get; set; }

        public virtual ICollection<Coursesection> Coursesections { get; set; }
        public virtual ICollection<Coursesequence> Coursesequences { get; set; }
    }
}
