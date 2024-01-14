using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyLearnHub.Core.DTO
{
    public class TokenPayload
    {
        public string Username { get; set; } = null!;
        public decimal? Userid { get; set; }
        public decimal? Roleid { get; set; }
        public int ?Isaccepted { get; set; }
    }
}
