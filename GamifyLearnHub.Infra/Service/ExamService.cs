using GamifyLearnHub.Core.Data;
using GamifyLearnHub.Core.DTO;
using GamifyLearnHub.Core.Repository;
using GamifyLearnHub.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyLearnHub.Infra.Service
{
    public class ExamService : IExamService
    {

        private readonly IExamRepository _examRepository;

        public ExamService(IExamRepository examRepository)
        {
            _examRepository = examRepository;
        }

        public async Task<int> CreateExam(Exam exam)
        {
            return await _examRepository.CreateExam(exam);
        }

        public async Task<int> DeleteExam(int id)
        {
            return await _examRepository.DeleteExam(id);
        }

        public async Task<List<Exam>> GetAllExams()
        {
            return await _examRepository.GetAllExams();
        }

        public async Task<Exam> GetExamById(int id)
        {
            return await _examRepository.GetExamById(id);
        }

        public async Task<List<StudentsMark>> GetUserMarks(int examId, int sectionId)
        {
            return await _examRepository.GetUserMarks(examId, sectionId);
        }

        public async Task<int> UpdateExam(Exam exam)
        {
            return await _examRepository.UpdateExam(exam);
        }
    }
}
