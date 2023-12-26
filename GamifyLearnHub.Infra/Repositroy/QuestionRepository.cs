using Dapper;
using GamifyLearnHub.Core.Common;
using GamifyLearnHub.Core.Data;
using GamifyLearnHub.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyLearnHub.Infra.Repositroy
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly IDbContext _dbContext;

        public QuestionRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> CreateQuestion(Question question)
        {
            var p = new DynamicParameters();
            p.Add("p_exam_id", question.Examid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_question_weight", question.Questionweight, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_question_description", question.Questiondescription, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("created_id", dbType: DbType.Int32, direction: ParameterDirection.Output);
            p.Add("rows_affected", dbType: DbType.Int32, direction: ParameterDirection.Output);

            await _dbContext.Connection.ExecuteAsync("Question_Package.CreateQuestion", p, commandType: CommandType.StoredProcedure);

            return p.Get<int>("created_id");
        }

        public async Task<int> DeleteQuestion(int id)
        {
            var p = new DynamicParameters();
            p.Add("p_question_id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("rows_affected", dbType: DbType.Int32, direction: ParameterDirection.Output);

            await _dbContext.Connection.ExecuteAsync("Question_Package.DeleteQuestion", p, commandType: CommandType.StoredProcedure);

            return p.Get<int>("rows_affected");
        }

        public async Task<List<Question>> GetAllQuestions()
        {
            var result = await _dbContext.Connection.QueryAsync<Question>("Question_Package.GetAllQuestions", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<Question> GetQuestionById(int id)
        {
            var p = new DynamicParameters();
            p.Add("p_question_id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = await _dbContext.Connection.QueryAsync<Question>("Question_Package.GetQuestionById", p, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }

        public async Task<int> UpdateQuestion(Question question)
        {
            var p = new DynamicParameters();
            p.Add("p_question_id", question.Questionid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_exam_id", question.Examid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_question_weight", question.Questionweight, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_question_description", question.Questiondescription, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("rows_affected", dbType: DbType.Int32, direction: ParameterDirection.Output);

            await _dbContext.Connection.ExecuteAsync("Question_Package.UpdateQuestion", p, commandType: CommandType.StoredProcedure);

            return p.Get<int>("rows_affected");
        }
    }
}
