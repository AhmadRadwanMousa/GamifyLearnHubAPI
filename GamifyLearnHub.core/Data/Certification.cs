using System;
using System.Collections.Generic;

namespace GamifyLearnHub.Core.Data
{
    public partial class Certification
    {
        public decimal Certificationid { get; set; }
        public decimal? Userid { get; set; }
        public DateTime? Dateearned { get; set; }
        public string? Certificationimage { get; set; }
        public decimal? Coursesequenceid { get; set; }

        public virtual Coursesequence? Coursesequence { get; set; }
        public virtual User? User { get; set; }
    }
}
