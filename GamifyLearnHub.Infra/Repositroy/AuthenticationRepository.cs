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
        public async Task<TokenPayload> Login(LoginCredentails loginDetails)
        {
            var p = new DynamicParameters();
            p.Add("user_name",loginDetails.Username,dbType:DbType.String,direction:ParameterDirection.Input);
            p.Add("user_password",loginDetails.Password,dbType:DbType.String,direction:ParameterDirection.Input);
            var result =await _dbContext.Connection.QueryAsync<TokenPayload>("LoginAndRegister_Package.Login", p,commandType:CommandType.StoredProcedure);
            return result.FirstOrDefault();         
        }
    }
}
