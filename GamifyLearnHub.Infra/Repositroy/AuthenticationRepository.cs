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
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly IDbContext _dbContext;
        public AuthenticationRepository(IDbContext dbContext)
        {
            _dbContext = dbContext; 
        }

        public async Task<int> IsUserNameExist(string userName)
        {
            var p = new DynamicParameters();
            p.Add("user_name", userName, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("isExist",  dbType: DbType.Int32, direction: ParameterDirection.Output);

            await _dbContext.Connection.ExecuteAsync
            ("LoginAndRegister_Package.IsUserNameExsit", p, commandType: CommandType.StoredProcedure);
            return p.Get<int>("isExist");
        }

        public async Task<TokenPayload> Login(LoginCredentails loginDetails)
        {
            var p = new DynamicParameters();
            p.Add("user_name",loginDetails.Username,dbType:DbType.String,direction:ParameterDirection.Input);
            p.Add("user_password",loginDetails.Password,dbType:DbType.String,direction:ParameterDirection.Input);
            var result =await _dbContext.Connection.QueryAsync<TokenPayload>("LoginAndRegister_Package.Login", p,commandType:CommandType.StoredProcedure);
            return result.FirstOrDefault();         
        }

        public async Task<int> ResetPassword(LoginCredentails loginDetails)
        {
            var p = new DynamicParameters();
            p.Add("user_name", loginDetails.Username, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("new_password", loginDetails.Password, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("rows_effected",dbType:DbType.Int32,direction: ParameterDirection.Output);

            await _dbContext.Connection.ExecuteAsync
            ("LoginAndRegister_Package.ResetPassword", p, commandType: CommandType.StoredProcedure);
            return p.Get<int>("rows_effected");
        }
    }
}
