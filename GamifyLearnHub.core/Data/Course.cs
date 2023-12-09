using System;
using System.Collections.Generic;

namespace GamifyLearnHub.Core.Data
{
    public partial class Course
    {
        public Course()
        {
            Certifications = new HashSet<Certification>();
            Coursesections = new HashSet<Coursesection>();
            Coursesequences = new HashSet<Coursesequence>();
            Sections = new HashSet<Section>();
        }

        public decimal Courseid { get; set; }
        public string Courselevel { get; set; } = null!;
        public string Coursename { get; set; } = null!;
        public string Courseimage { get; set; } = null!;
        public decimal Examweight { get; set; }
        public decimal Assignmentweight { get; set; }
        public decimal Quizzezweight { get; set; }

        public virtual ICollection<Certification> Certifications { get; set; }
        public virtual ICollection<Coursesection> Coursesections { get; set; }
        public virtual ICollection<Coursesequence> Coursesequences { get; set; }
        public virtual ICollection<Section> Sections { get; set; }
    }
}
