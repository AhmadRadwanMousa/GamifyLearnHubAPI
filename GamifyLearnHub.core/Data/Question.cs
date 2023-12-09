using System;
using System.Collections.Generic;

namespace GamifyLearnHub.Core.Data
{
    public partial class Question
    {
        public Question()
        {
            Questionoptions = new HashSet<Questionoption>();
        }

        public decimal Questionid { get; set; }
        public decimal? Examid { get; set; }
        public decimal Questionweight { get; set; }
        public string Questiondescription { get; set; } = null!;

        public virtual Exam? Exam { get; set; }
        public virtual ICollection<Questionoption> Questionoptions { get; set; }
    }
}
