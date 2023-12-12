using GamifyLearnHub.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyLearnHub.Core.DTO
{
    public class AttendenceWithDetails
    {
        public Attendence attendence { get; set; }
        public List<Attendencedetail> attendencedetail { get; set; }
    }
}
