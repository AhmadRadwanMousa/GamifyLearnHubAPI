using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyLearnHub.Core.DTO
{
    public class SolutionUserDetails
    {
        public decimal Questionid { get; set; }
        public decimal Questionweight { get; set; }
        public string Questiondescription { get; set; } = null!;
        public decimal Questionoptionid { get; set; }
        public string Questionoptiondescription { get; set; } = null!;
        public bool? Iscorrect { get; set; }
        public decimal Examsolutionid { get; set; }
        public decimal userQuestionOptionId { get; set; }

}
}
