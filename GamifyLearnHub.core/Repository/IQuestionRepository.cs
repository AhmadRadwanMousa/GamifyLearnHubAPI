using GamifyLearnHub.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyLearnHub.Core.Repository
{
    public interface IQuestionRepository
    {
        Task<List<Question>> GetAllQuestions();
        Task<Question> GetQuestionById(int id);
        Task<int> CreateQuestion(Question question);
        Task<int> UpdateQuestion(Question question);
        Task<int> DeleteQuestion(int id);
    }
}
