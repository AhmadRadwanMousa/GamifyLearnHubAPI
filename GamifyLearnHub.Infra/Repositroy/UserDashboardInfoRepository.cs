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
    public class UserDashboardInfoRepository : IUserDashboardInfoRepository
    {
        private readonly IDbContext _dbContext;

        public UserDashboardInfoRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<CompletedCourses>> CompletedCoursesByUserId(int id)
        {
            var p = new DynamicParameters();
            p.Add("id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = await _dbContext.Connection.QueryAsync<CompletedCourses>("UserDashboardInfo_Package.CompletedCoursesByUserId", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<List<Attendence>> UserDashboardAttendence(decimal userId, decimal sectionId)
        {
            var p = new DynamicParameters();
            p.Add("p_userid", userId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_sectionid", sectionId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = await _dbContext.Connection.QueryAsync<Attendence>("UserDashboardInfo_Package.UserDashboardAttendence", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<UserDashboarInfo> UserDashboardInfoByUserId(int id)
        {
            var p = new DynamicParameters();
            p.Add("id", id, dbType: DbType.Int32, direction:ParameterDirection.Input);
            var result = await _dbContext.Connection.QueryAsync<UserDashboarInfo>("UserDashboardInfo_Package.UserDashboardInfoByUserId",p,commandType:CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }
    }
}
