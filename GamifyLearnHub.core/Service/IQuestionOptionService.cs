using GamifyLearnHub.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyLearnHub.Core.Service
{
    public interface IQuestionOptionService
    {
        Task<List<Questionoption>> GetAllQuestionOpstions();
        Task<Questionoption> GetQuestionOpstionById(int id);
        Task<int> CreateQuestionOption(Questionoption questionoption);
        Task<int> UpdateQuestionOption(Questionoption questionoption);
        Task<int> DeleteQuestionOption(int id);
    }
}
