using GamifyLearnHub.Core.Data;
using GamifyLearnHub.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyLearnHub.Core.Repository
{
    public interface IExamLearnerRepository
    {
        Task<List<ExamLearner>> GetExamDetails(int id);
        void CreateExamSolution(Examsolution examsolutions);
        Task<QuestionOptionDetails> GetSolution(int id);
        Task<int> CreateExamSolutionDetails(Examsolutiondetail examsolutiondetail);

        Task<List<SolutionUserDetails>> GetSolutionUserDetails(int examId, int userId);
       Task<List<Exam>> GetExamsToday(int sectionId);

        Task<List<Section>> GetAllSectionsByLearnerId(int userId);

        Task<List<ExamsBySection>> GetAllExamByUserSection(int userId , int sectionId);

        Task<Examsolutiondetail> GetExamDetailsByUserId(int userId, int examid);
    }
}
