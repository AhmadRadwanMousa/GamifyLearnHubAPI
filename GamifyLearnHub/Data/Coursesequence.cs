using System;
using System.Collections.Generic;

namespace GamifyLearnHub.Data
{
    public partial class Coursesequence
    {
        public Coursesequence()
        {
            Certifications = new HashSet<Certification>();
            Sections = new HashSet<Section>();
        }

        public decimal Coursesequenceid { get; set; }
        public decimal? Courseid { get; set; }
        public decimal? Programid { get; set; }
        public decimal? Perviouscourseid { get; set; }
        public DateTime Startdate { get; set; }
        public DateTime? Enddate { get; set; }

        public virtual Course? Course { get; set; }
        public virtual Program? Program { get; set; }
        public virtual ICollection<Certification> Certifications { get; set; }
        public virtual ICollection<Section> Sections { get; set; }
    }
}
