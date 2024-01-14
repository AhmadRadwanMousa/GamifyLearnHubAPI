using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyLearnHub.Core.DTO
{
    public class UpdateUserBadgeDetails
    {
        public int Userbadgeactivityid { get; set; }
        public string? Username { get; set; }
        public string ?Badgeimage { get; set; }
        public int ?Badgeactivityid { get; set; }
    }
}
