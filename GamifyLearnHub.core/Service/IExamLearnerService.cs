using GamifyLearnHub.Core.Data;
using GamifyLearnHub.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyLearnHub.Core.Service
{
    public interface IExamLearnerService
    {
        Task<List<ExamLearner>> GetExamDetails(int id);

        Task<int> CreateExamSolution(List<Examsolution> examsolutions);

        Task<List<SolutionUserDetails>> GetSolutionUserDetails(int examId, int userId);

        Task<List<Exam>> GetExamsToday(int sectionId);

        Task<List<Section>> GetAllSectionsByLearnerId(int userId);
        Task<List<Exam>> GetAllExamByUserSection(int userId, int sectionId);


    }
}
