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
    public class QuestionOptionRepository : IQuestionOptionRepository
    {
        private readonly IDbContext _dbContext;

        public QuestionOptionRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> CreateQuestionOption(Questionoption questionoption)
        {
            var p = new DynamicParameters();
            p.Add("questionOption_Id", dbType: DbType.Int32, direction: ParameterDirection.Output);
            p.Add("question_Id", questionoption.Questionid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("QuestionOptionDesc", questionoption.Questionoptiondescription, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Is_Correct", questionoption.Iscorrect, dbType: DbType.Int32, direction: ParameterDirection.Input);

            await _dbContext.Connection.ExecuteAsync("QuestionOption_Package.CreateQuestionOption", p, commandType: CommandType.StoredProcedure);

            return p.Get<int>("questionOption_Id");
        }

        public async Task<int> DeleteQuestionOption(int id)
        {
            var p = new DynamicParameters();
            p.Add("questionOption_Id", id, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("rows_effected", dbType: DbType.Int32, direction: ParameterDirection.Output);

            await _dbContext.Connection.ExecuteAsync("QuestionOption_Package.DeleteQuestionOption", p, commandType: CommandType.StoredProcedure);

            return p.Get<int>("rows_effected");
        }
        public async Task<List<Questionoption>> GetQuestionOpstionById(int id)
        {
            var p = new DynamicParameters();
            p.Add("question_Id", id, dbType: DbType.Decimal, direction: ParameterDirection.Input);

            var result = await _dbContext.Connection.QueryAsync<Questionoption>("QuestionOption_Package.GetQuestionOptionByQuestionId", p, commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public async Task<int> UpdateQuestionOption(Questionoption questionoption)
        {
            var p = new DynamicParameters();
            p.Add("questionOption_Id", questionoption.Questionoptionid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("question_Id", questionoption.Questionid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("QuestionOptionDesc", questionoption.Questionoptiondescription, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Is_Correct", questionoption.Iscorrect, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("rows_effected", dbType: DbType.Int32, direction: ParameterDirection.Output);

            await _dbContext.Connection.ExecuteAsync("QuestionOption_Package.UpdateQuestionOption", p, commandType: CommandType.StoredProcedure);

            return p.Get<int>("rows_effected");
        }
    }
}
