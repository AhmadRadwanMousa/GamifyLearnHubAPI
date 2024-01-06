using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyLearnHub.Core.DTO
{
    public class StudentsMark
    {
        public string Firsname { get; set; } = null!;
        public string Lastname { get; set; } = null!;
        public decimal Examsolutionmark { get; set; }
        public decimal Exammark { get; set; }
    }
}
