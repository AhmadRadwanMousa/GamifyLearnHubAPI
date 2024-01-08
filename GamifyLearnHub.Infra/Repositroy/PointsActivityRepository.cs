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
    public class PointsActivityRepository : IPointsActivityRepository
    {
        private readonly IDbContext _dbContext;

        public PointsActivityRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> CreateNewPointsActivity(Pointsactivity pointsactivity)
        {
            var p = new DynamicParameters();
            p.Add("pointsActivity_Id", dbType: DbType.Int32, direction: ParameterDirection.Output);
            p.Add("activityPoints", pointsactivity.Points, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("pointsActivity_Name", pointsactivity.Pointsactivityname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("number_Of_Courses", pointsactivity.Numberofcourses, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("number_Of_Days", pointsactivity.Numberofdays, dbType: DbType.Int32, direction: ParameterDirection.Input);
            await _dbContext.Connection.ExecuteAsync("PointsActivity_Package.CreateNewPointsActivity", p, commandType: CommandType.StoredProcedure);

            return p.Get<int>("pointsActivity_Id");
        }

        public async Task<List<Pointsactivity>> GetAll()
        {
            var result = await _dbContext.Connection.QueryAsync<Pointsactivity>("PointsActivity_Package.GetAllPointsActivity", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<int> UpdatePointsActivity(Pointsactivity pointsactivity)
        {
            var p = new DynamicParameters();
            p.Add("pointsActivity_Id", pointsactivity.Pointsactivityid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("activityPoints", pointsactivity.Points, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("pointsActivity_Name", pointsactivity.Pointsactivityname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("rows_effected", dbType: DbType.Int32, direction: ParameterDirection.Output);

            await _dbContext.Connection.ExecuteAsync("PointsActivity_Package.UpdatePointsActivity", p, commandType: CommandType.StoredProcedure);

            return p.Get<int>("rows_effected");
        }
    }
}
