using System;
using System.Collections.Generic;

namespace GamifyLearnHub.Core.Data
{
    public partial class Userlogin
    {
        public decimal Userloginid { get; set; }
        public decimal? Userid { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public decimal? Roleid { get; set; }
        public bool? Isonline { get; set; }
        public bool? Isaccepted { get; set; }
        public string Password { get; set; } = null!;
        public DateTime? Lastlogin { get; set; }
        public decimal? Dayscount { get; set; }

        public virtual Role? Role { get; set; }
        public virtual User? User { get; set; }
    }
}
