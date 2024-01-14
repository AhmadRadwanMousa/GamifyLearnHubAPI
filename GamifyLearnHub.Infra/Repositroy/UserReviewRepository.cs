using Dapper;
using GamifyLearnHub.Core.Common;
using GamifyLearnHub.Core.Data;
using GamifyLearnHub.Core.DTO;
using GamifyLearnHub.Core.Repository;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyLearnHub.Infra.Repositroy
{
    public class UserReviewRepository : IUserReviewRepository
    {
        private readonly IDbContext _dbContext;

        public UserReviewRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<FinishedProgram>> GetFinishedPrograms(int userId)
        {
            var p = new DynamicParameters();
            p.Add("p_user_id", userId, DbType.Int32, ParameterDirection.Input);
            var result =  await _dbContext.Connection.QueryAsync<FinishedProgram>("UserReview_Package.check_certificates_for_program", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }


        public async Task<int> CreateUserReview(Userreview userReview)
        {
            var p = new DynamicParameters();
            p.Add("User_Id", userReview.Userid, DbType.Int32, ParameterDirection.Input);
            p.Add("Program_Id", userReview.Programid, DbType.Int32, ParameterDirection.Input);
            p.Add("Review_Rate", userReview.Reviewrate, DbType.Int32, ParameterDirection.Input);
            p.Add("Review_Content", userReview.Reviewcontent, DbType.String, ParameterDirection.Input);
            p.Add("CreatedId", DbType.Int32, direction: ParameterDirection.Output);

            await _dbContext.Connection.ExecuteAsync("UserReview_Package.CreateUserReview", p, commandType:CommandType.StoredProcedure);

            return p.Get<int>("CreatedId");
        }

        public async Task<int> DeleteUserReview(int id)
        {
            var p = new DynamicParameters();
            p.Add("UserReview_Id", id, DbType.Int32, ParameterDirection.Input);
            p.Add("RowsAffected", DbType.Int32, direction: ParameterDirection.Output);

            await _dbContext.Connection.ExecuteAsync("UserReview_Package.DeleteUserReview", p, commandType: CommandType.StoredProcedure);

            return p.Get<int>("RowsAffected");
        }

        public async Task<List<Userreview>> GetAllUserReviews()
        {
            var result = await _dbContext.Connection.QueryAsync<Userreview, User, Program, Userreview>("UserReview_Package.GetAllUserReviews",
                (UserReview, user, program) =>
                {
                    UserReview.User = user;
                    UserReview.Program = program;
                    return UserReview;
                },
                splitOn: "userid, programid",
                commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<Userreview> GetUserReviewById(int id)
        {
            var p = new DynamicParameters();
            p.Add("UserReview_Id", id, DbType.Int32, ParameterDirection.Input);

            var result = await _dbContext.Connection.QueryAsync<Userreview, User, Program, Userreview>("UserReview_Package.GetUserReviewById",
                (UserReview, user, program) => 
                {
                    UserReview.User = user;
                    UserReview.Program = program;
                    return UserReview;
                },
                p,
                splitOn: "userid, programid",
                commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public async Task<int> UpdateUserReview(Userreview userReview)
        {
            var p = new DynamicParameters();
            p.Add("UserReview_Id", userReview.Userreviewid, DbType.Int32, ParameterDirection.Input);
            p.Add("User_Id", userReview.Userid, DbType.Int32, ParameterDirection.Input);
            p.Add("Program_Id", userReview.Programid, DbType.Int32, ParameterDirection.Input);
            p.Add("Review_Rate", userReview.Reviewrate, DbType.Int32, ParameterDirection.Input);
            p.Add("Review_Content", userReview.Reviewcontent, DbType.String, ParameterDirection.Input);
            p.Add("RowsAffected", DbType.Int32, direction: ParameterDirection.Output);

            await _dbContext.Connection.ExecuteAsync("UserReview_Package.UpdateUserReview", p, commandType: CommandType.StoredProcedure);

            return p.Get<int>("RowsAffected");
        }
    }
}
