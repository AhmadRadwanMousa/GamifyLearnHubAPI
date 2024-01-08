using Dapper;
using GamifyLearnHub.Core.Common;
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
    public class AdminLeaderBoardRepository : IAdminLeaderBoardRepository
    {
        private readonly IDbContext _dbContext;

        public AdminLeaderBoardRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<AdminStatistics>> AdminStatistics()
        {
            var result = await _dbContext.Connection.QueryAsync<AdminStatistics>("Admin_leaderboard_Package.AdminStatistics", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<int> InstructorStudents(int id)
        {
            var p = new DynamicParameters();
            p.Add("id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("numOfStudents", dbType:DbType.Int32, direction:ParameterDirection.Output);
            await _dbContext.Connection.ExecuteAsync("Admin_leaderboard_Package.InstructorStudents", p, commandType:CommandType.StoredProcedure);
            return p.Get<int>("numOfStudents");
        }

        public async Task<List<RankByBadges>> RankByBadgesStudents()
        {
            var result = await _dbContext.Connection.QueryAsync<RankByBadges>("Admin_leaderboard_Package.OrderByBadges", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<List<RankByPoints>> RankByPointsInstructorStudents(int id)
        {
            var p = new DynamicParameters();
            p.Add("id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = await _dbContext.Connection.QueryAsync<RankByPoints>("Admin_leaderboard_Package.OrderByPointsInstructor", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<List<RankByPoints>> RankByPointsStudents()
        {
            var result = await _dbContext.Connection.QueryAsync<RankByPoints>("Admin_leaderboard_Package.OrderByPoints",commandType:CommandType.StoredProcedure);
            return result.ToList();
        }
    }
}
