using Dapper;
using GamifyLearnHub.Core.Common;
using GamifyLearnHub.Core.Data;
using GamifyLearnHub.Core.DTO;
using GamifyLearnHub.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyLearnHub.Infra.Repositroy
{
    public class UserProgressRepository : IUserProgressRepository
    {
        private readonly IDbContext _dbContext;

        public UserProgressRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Userprogress>> GetAllUserProgress()
        {
            var result = await _dbContext.Connection.QueryAsync<Userprogress>(
                "UserProgress_Package.GetAllUserProgress",
                commandType: CommandType.StoredProcedure
            );

            return result;
        }

        public async Task<Userprogress> GetUserProgressById(decimal id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("id", id, DbType.Decimal, ParameterDirection.Input);

            var result = await _dbContext.Connection.QueryAsync<Userprogress>(
                "UserProgress_Package.GetUserProgressById",
                parameters,
                commandType: CommandType.StoredProcedure
            );

            return result.FirstOrDefault();
        }

        public async Task<decimal> CreateUserProgress(Userprogress userprogress)
        {
            var parameters = new DynamicParameters();
            parameters.Add("user_id", userprogress.Userid, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("lecture_id", userprogress.Lectureid, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("section_id",userprogress.Sectionid , DbType.Decimal, ParameterDirection.Input);
            parameters.Add("created_id", dbType: DbType.Decimal, direction: ParameterDirection.Output);

            await _dbContext.Connection.ExecuteAsync(
                "UserProgress_Package.CreateUserProgress",
                parameters,
                commandType: CommandType.StoredProcedure
            );

            return parameters.Get<decimal>("created_id");
        }

        public async Task<int> UpdateUserProgress(decimal id, decimal user_id, decimal lecture_id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("id", id, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("user_id", user_id, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("lecture_id", lecture_id, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("rows_updated", dbType: DbType.Int32, direction: ParameterDirection.Output);

            await _dbContext.Connection.ExecuteAsync(
                "UserProgress_Package.UpdateUserProgress",
                parameters,
                commandType: CommandType.StoredProcedure
            );

            return parameters.Get<int>("rows_updated");
        }

        public async Task<int> DeleteUserProgress(decimal id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("id", id, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("rows_deleted", dbType: DbType.Int32, direction: ParameterDirection.Output);

            await _dbContext.Connection.ExecuteAsync(
                "UserProgress_Package.DeleteUserProgress",
                parameters,
                commandType: CommandType.StoredProcedure
            );

            return parameters.Get<int>("rows_deleted");
        }

        public async Task<List<Userprogress>> GetUserProgressBySectionAndUserId(int userId, int sectionId)
        {
            var p = new DynamicParameters();
            p.Add("user_id",userId,dbType:DbType.Int32, direction: ParameterDirection.Input);
            p.Add("section_id", sectionId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = await _dbContext.Connection.QueryAsync<Userprogress>
                ("UserProgress_Package.GetUserProgessBySectionAndUserId", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<List<UserProgressPerCourse>> GetProgressPerCourse(int userId, int programId)
        {
            var p = new DynamicParameters();
            p.Add("user_id",userId, dbType:DbType.Int32, direction:ParameterDirection.Input);
            p.Add("program_id",programId, dbType: DbType.Int32, direction:ParameterDirection.Input) ;
            var result=await _dbContext.Connection.QueryAsync<UserProgressPerCourse>
            ("UserProgress_Package.GetProgressPerCourse", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
    }
}
