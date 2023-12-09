using System;
using System.Collections.Generic;

namespace GamifyLearnHub.Core.Data
{
    public partial class Usersection
    {
        public Usersection()
        {
            Userpointsactivities = new HashSet<Userpointsactivity>();
        }

        public decimal Usersectionid { get; set; }
        public decimal? Userid { get; set; }
        public decimal? Sectionid { get; set; }
        public DateTime? Enrollmentdate { get; set; }
        public decimal? Studentmark { get; set; }

        public virtual Section? Section { get; set; }
        public virtual User? User { get; set; }
        public virtual ICollection<Userpointsactivity> Userpointsactivities { get; set; }
    }
}
