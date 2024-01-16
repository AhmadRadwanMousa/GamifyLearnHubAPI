using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyLearnHub.Core.DTO
{
    public class CertificationUser
    {
        public decimal? Userid { get; set; }
        public string Username { get; set; } = null!;

        public decimal Coursesequenceid { get; set; }
        public string Firsname { get; set; } = null!;
        public string Lastname { get; set; } = null!;
        public string Coursename { get; set; } = null!;
        public decimal Sectionid { get; set; }


    }
}
