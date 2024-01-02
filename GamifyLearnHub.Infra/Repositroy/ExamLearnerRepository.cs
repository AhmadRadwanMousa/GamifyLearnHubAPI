using Dapper;
using GamifyLearnHub.Core.Common;
using GamifyLearnHub.Core.Data;
using GamifyLearnHub.Core.DTO;
using GamifyLearnHub.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace GamifyLearnHub.Infra.Repositroy
{
    public class ExamLearnerRepository : IExamLearnerRepository
    {
        private readonly IDbContext _dbContext;

        public ExamLearnerRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void CreateExamSolution(Examsolution examsolutions)
        {
            var p = new DynamicParameters();
            p.Add("user_Id", examsolutions.Userid, DbType.Int32, direction: ParameterDirection.Input);
            p.Add("questionOption_Id", examsolutions.Questionoptionid, DbType.Int32, direction: ParameterDirection.Input);
            p.Add("examSolution_Id", DbType.Int32, direction: ParameterDirection.Output);

            _dbContext.Connection.ExecuteAsync("ExamSolution_Package.CreateExamSolution", p, commandType: CommandType.StoredProcedure);
        }

        public async Task<QuestionOptionDetails> GetSolution(int id)
        {
            var p = new DynamicParameters();
            p.Add("p_questionOptionId", id, DbType.Int32, direction: ParameterDirection.Input);
            var result = await _dbContext.Connection.QueryAsync<QuestionOptionDetails>("LearnerExam_Package.GetQuestionOptionDetails", p, commandType: CommandType.StoredProcedure);
            return  result.FirstOrDefault();


        }


        public async Task<int> CreateExamSolutionDetails(Examsolutiondetail examsolutiondetail)
        {
            var p = new DynamicParameters();
            p.Add("exam_Id", examsolutiondetail.Examid, DbType.Int32, direction: ParameterDirection.Input);
            p.Add("user_Id", examsolutiondetail.Userid, DbType.Int32, direction: ParameterDirection.Input);
            p.Add("examSolution_Mark", examsolutiondetail.Examsolutionmark, DbType.Int32, direction: ParameterDirection.Input);
            p.Add("examSolutionDetails_Id", DbType.Int32, direction: ParameterDirection.Output);
            _dbContext.Connection.ExecuteAsync("ExamSolutionDetails_Package.CreateExamSolutionDetails", p, commandType: CommandType.StoredProcedure);
            return p.Get<int>("examSolutionDetails_Id");

        }

        public async Task<List<ExamLearner>> GetExamDetails(int id)
        {

            var p = new DynamicParameters();
            p.Add("p_examId", id, DbType.Int32, direction: ParameterDirection.Input);
            var result = await _dbContext.Connection.QueryAsync<ExamLearner>("LearnerExam_Package.GetExamDetails", p, commandType: CommandType.StoredProcedure);
            return result.ToList();

       
        }

        public async Task<List<SolutionUserDetails>> GetSolutionUserDetails(int examId, int userId)
        {
            var p = new DynamicParameters();
            p.Add("p_examId", examId, DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_userId", userId, DbType.Int32, direction: ParameterDirection.Input);

            var result = await _dbContext.Connection.QueryAsync<SolutionUserDetails>("LearnerExam_Package.GetSolutionUserDetails", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<List<Exam>> GetExamsToday(int sectionId)
        {
            var p = new DynamicParameters();
            p.Add("p_sectionId", sectionId, DbType.Int32, direction: ParameterDirection.Input);

            var result = await _dbContext.Connection.QueryAsync<Exam>("LearnerExam_Package.GetExamsToday", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<List<Core.Data.Section>> GetAllSectionsByLearnerId(int userId)
        {
            var p = new DynamicParameters();
            p.Add("user_Id", userId, DbType.Int32, direction: ParameterDirection.Input);

            var result = await _dbContext.Connection.QueryAsync<Core.Data.Section>("UserExam_Package.GetAllSectionsByLearnerId", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<List<Exam>> GetAllExamByUserSection(int userId, int sectionId)
        {
            var p = new DynamicParameters();
            p.Add("user_Id", userId, DbType.Int32, direction: ParameterDirection.Input);
            p.Add("section_Id", sectionId, DbType.Int32, direction: ParameterDirection.Input);

            var result = await _dbContext.Connection.QueryAsync<Exam>("UserExam_Package.GetAllExamByUserSection", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
    }
}
