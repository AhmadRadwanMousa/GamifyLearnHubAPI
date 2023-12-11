using GamifyLearnHub.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyLearnHub.Core.DTO
{
    public class QuestionWithOptions
    {
        public Question question { get; set; }
        public List<Questionoption> questionOption { get; set; }
    }
}
