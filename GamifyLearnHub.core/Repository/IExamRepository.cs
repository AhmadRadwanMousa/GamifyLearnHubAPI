using GamifyLearnHub.Core.Data;
using GamifyLearnHub.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyLearnHub.Core.Repository
{
    public interface IExamRepository
    {
        Task<List<Exam>> GetAllExams();
        Task<Exam> GetExamById(int id);
        Task<int> CreateExam(Exam exam);
        Task<int> UpdateExam(Exam exam);
        Task<int> DeleteExam(int id);

        Task<List<StudentsMark>> GetUserMarks(int examId , int sectionId);
    }
}
