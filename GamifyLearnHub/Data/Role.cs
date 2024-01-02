using System;
using System.Collections.Generic;

namespace GamifyLearnHub.Data
{
    public partial class Role
    {
        public Role()
        {
            Userlogins = new HashSet<Userlogin>();
        }

        public decimal Roleid { get; set; }
        public string Rolename { get; set; } = null!;

        public virtual ICollection<Userlogin> Userlogins { get; set; }
    }
}
