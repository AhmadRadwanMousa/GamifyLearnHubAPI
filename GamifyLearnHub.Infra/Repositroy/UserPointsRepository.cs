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
    public class UserPointsRepository : IUserPointsRepository
    {
        private readonly IDbContext _dbContext;
        public UserPointsRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Userpointsactivity>> GetAllUnViewedUserPoints(int userId)
        {
            var p = new DynamicParameters();
            p.Add("user_id", userId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = await _dbContext.Connection.QueryAsync<Userpointsactivity, Pointsactivity, Userpointsactivity>(
      "UserPointsActivity_Package.GetUnViewedUserPointsActivity",
      (userPoints, points) =>
      {
          userPoints.Pointsactivity = points;
          return userPoints;
      },
      p,
      splitOn: "pointsactivityid", 
      commandType: CommandType.StoredProcedure
  );
            return result.ToList();
        }

        public async Task<int> UpdateUserPointsState(int userPointsId)
        {
            var p = new DynamicParameters();
            p.Add("userPoints_id", userPointsId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("rows_effected",  dbType: DbType.Int32, direction: ParameterDirection.Output);
           await _dbContext.Connection.ExecuteAsync
                ("UserPointsActivity_Package.UpdateIsViewedUserPoints", p, commandType: CommandType.StoredProcedure);
            return p.Get<int>("rows_effected");

        }
    }
}
