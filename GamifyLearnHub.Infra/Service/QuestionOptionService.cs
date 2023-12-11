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
    public class QuestionOptionService : IQuestionOptionService
    {
        private readonly IQuestionOptionRepository _questionOptionRepository;

        public QuestionOptionService(IQuestionOptionRepository questionOptionRepository)
        {
            _questionOptionRepository = questionOptionRepository;
        }

        public async Task<int> CreateQuestionOption(Questionoption questionoption)
        {
            return await _questionOptionRepository.CreateQuestionOption(questionoption);
        }

        public async Task<int> DeleteQuestionOption(int id)
        {
            return await _questionOptionRepository.DeleteQuestionOption(id);
        }

        public async Task<List<Questionoption>> GetAllQuestionOpstions()
        {
            return await _questionOptionRepository.GetAllQuestionOpstions();
        }

        public async Task<Questionoption> GetQuestionOpstionById(int id)
        {
            return await _questionOptionRepository.GetQuestionOpstionById(id);
        }

        public async Task<int> UpdateQuestionOption(Questionoption questionoption)
        {
            return await _questionOptionRepository.UpdateQuestionOption(questionoption);
        }
    }
}
