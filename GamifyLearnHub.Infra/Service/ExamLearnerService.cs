using GamifyLearnHub.Core.Data;
using GamifyLearnHub.Core.DTO;
using GamifyLearnHub.Core.Repository;
using GamifyLearnHub.Core.Service;
using GamifyLearnHub.Infra.Repositroy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyLearnHub.Infra.Service
{
    public class ExamLearnerService : IExamLearnerService
    {
        private readonly IExamLearnerRepository _examLearnerRepository;
        public ExamLearnerService(IExamLearnerRepository examLearnerRepository)
        {
            _examLearnerRepository = examLearnerRepository;
        }

        public async Task<int> CreateExamSolution(List<Examsolution> examsolutions)
        {
            var totalMark = 0;
            var examId=0;
            for (int i = 0; i < examsolutions.Count; i++)
            {
                var solutionResult = await _examLearnerRepository.GetSolution(Convert.ToInt32(examsolutions[i].Questionoptionid));

                QuestionOptionDetails questionOptionDetails = new QuestionOptionDetails
                {
                    Iscorrect = solutionResult.Iscorrect,
                   Questionweight = solutionResult.Questionweight,
                   Examid = solutionResult.Examid,
                };
                examId = Convert.ToInt32(questionOptionDetails.Examid);

                if (questionOptionDetails.Iscorrect == true) {
                    totalMark += Convert.ToInt32(questionOptionDetails.Questionweight);
                }
                _examLearnerRepository.CreateExamSolution(examsolutions[i]);
            }

            Examsolutiondetail examsolutiondetail = new Examsolutiondetail();
            examsolutiondetail.Examid = examId;
            examsolutiondetail.Userid = examsolutions[0].Userid;
            examsolutiondetail.Examsolutionmark = totalMark;
            var complete = await  _examLearnerRepository.CreateExamSolutionDetails(examsolutiondetail);
            return complete;
        }

        public async Task<List<ExamsBySection>> GetAllExamByUserSection(int userId, int sectionId)
        {
            return await _examLearnerRepository.GetAllExamByUserSection(userId, sectionId);
        }

        public async Task<List<Section>> GetAllSectionsByLearnerId(int userId)
        {
            return await _examLearnerRepository.GetAllSectionsByLearnerId(userId);
        }

        public async Task<List<ExamLearner>> GetExamDetails(int id)
        {
           return await _examLearnerRepository.GetExamDetails(id);
        }

        public async Task<Examsolutiondetail> GetExamDetailsByUserId(int userId, int examid)
        {
            return await _examLearnerRepository.GetExamDetailsByUserId(userId, examid);
        }

        public async Task<List<Exam>> GetExamsToday(int sectionId)
        {
            return await _examLearnerRepository.GetExamsToday(sectionId);
          }

        public async Task<List<SolutionUserDetails>> GetSolutionUserDetails(int examId, int userId)
        {
            return await _examLearnerRepository.GetSolutionUserDetails( examId, userId);
        }
    }
}
