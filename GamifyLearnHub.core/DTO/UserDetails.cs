using GamifyLearnHub.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyLearnHub.Core.DTO
{
    public class UserDetails
    {
        //User
        public decimal Userid { get; set; }
        public string Firsname { get; set; } = null!;
        public string Lastname { get; set; } = null!;
        public decimal? Totalpoints { get; set; }
        public DateTime Dateofbirth { get; set; }
        public string? Userimage { get; set; }

        //UserLogin 
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public decimal? Roleid { get; set; }
        public bool? Isonline { get; set; }
        public bool? Isaccepted { get; set; }
        public DateTime Lastlogin { get; set; }
        public decimal? Dayscount { get; set; }


    }
}
