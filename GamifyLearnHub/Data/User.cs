using System;
using System.Collections.Generic;

namespace GamifyLearnHub.Data
{
    public partial class User
    {
        public User()
        {
            Assignmentsolutiondetails = new HashSet<Assignmentsolutiondetail>();
            Assignmentsolutions = new HashSet<Assignmentsolution>();
            Attendencedetails = new HashSet<Attendencedetail>();
            Carts = new HashSet<Cart>();
            Certifications = new HashSet<Certification>();
            Examsolutiondetails = new HashSet<Examsolutiondetail>();
            Examsolutions = new HashSet<Examsolution>();
            Payments = new HashSet<Payment>();
            Sections = new HashSet<Section>();
            Userbadgeactivities = new HashSet<Userbadgeactivity>();
            Usercoupons = new HashSet<Usercoupon>();
            Userlogins = new HashSet<Userlogin>();
            Userpointsactivities = new HashSet<Userpointsactivity>();
            Userprogresses = new HashSet<Userprogress>();
            Usersections = new HashSet<Usersection>();
        }

        public decimal Userid { get; set; }
        public string Firsname { get; set; } = null!;
        public string Lastname { get; set; } = null!;
        public decimal? Totalpoints { get; set; }
        public DateTime Dateofbirth { get; set; }
        public string? Userimage { get; set; }

        public virtual ICollection<Assignmentsolutiondetail> Assignmentsolutiondetails { get; set; }
        public virtual ICollection<Assignmentsolution> Assignmentsolutions { get; set; }
        public virtual ICollection<Attendencedetail> Attendencedetails { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<Certification> Certifications { get; set; }
        public virtual ICollection<Examsolutiondetail> Examsolutiondetails { get; set; }
        public virtual ICollection<Examsolution> Examsolutions { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
        public virtual ICollection<Section> Sections { get; set; }
        public virtual ICollection<Userbadgeactivity> Userbadgeactivities { get; set; }
        public virtual ICollection<Usercoupon> Usercoupons { get; set; }
        public virtual ICollection<Userlogin> Userlogins { get; set; }
        public virtual ICollection<Userpointsactivity> Userpointsactivities { get; set; }
        public virtual ICollection<Userprogress> Userprogresses { get; set; }
        public virtual ICollection<Usersection> Usersections { get; set; }
    }
}
