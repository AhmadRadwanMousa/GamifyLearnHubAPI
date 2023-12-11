using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyLearnHub.Core.DTO
{
    public class ExamLearner
    {
        public int ExamId { get; set; }
        public int SectionId { get; set; }
        public string Examtype { get; set; } = null!;
        public DateTime ExamDate { get; set; }
        public int ExamMark { get; set; }

        public int QuestionId { get; set; }
        public int QuestionWeight { get; set; }
        public string Questiondescription { get; set; } = null!;

        public int QuestionOptionId { get; set; }
        public string Questionoptiondescription { get; set; } = null!;
        public int? IsCorrect { get; set; }
    }
}
