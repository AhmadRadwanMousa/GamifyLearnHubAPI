using GamifyLearnHub.Core.Data;
using GamifyLearnHub.Core.Repository;
using GamifyLearnHub.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyLearnHub.Infra.Service
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _questionRepository;

        public QuestionService(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        public async Task<int> CreateQuestion(Question question)
        {
            return await _questionRepository.CreateQuestion(question);
        }

        public async Task<int> DeleteQuestion(int id)
        {
            return await _questionRepository.DeleteQuestion(id);
        }

        public async Task<List<Question>> GetAllQuestions()
        {
            return await _questionRepository.GetAllQuestions();
        }

        public async Task<Question> GetQuestionById(int id)
        {
            return await _questionRepository.GetQuestionById(id);
        }

        public async Task<int> UpdateQuestion(Question question)
        {
            return await _questionRepository.UpdateQuestion(question);
        }
    }
}
