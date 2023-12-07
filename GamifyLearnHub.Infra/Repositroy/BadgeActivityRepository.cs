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
    public class BadgeActivityRepository : IBadgeActivityRepository
    {
        private readonly IDbContext _dbContext;

        public BadgeActivityRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Badgeactivity>> GetAll()
        {
            var result = await _dbContext.Connection.QueryAsync<Badgeactivity>("BadgeActivity_Package.GetAllBadgeActivities", commandType:CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<int> UpdateBadgeActivity(Badgeactivity badgeactivity)
        {
            var p = new DynamicParameters();
            p.Add("BadgeActivity_Id",badgeactivity.Badgeactivityid, dbType:DbType.Int32, direction:ParameterDirection.Input);
            p.Add("Badge_Image", badgeactivity.Badgeimage, dbType:DbType.String, direction:ParameterDirection.Input);
            p.Add("Badge_Points", badgeactivity.Badgepoints, dbType:DbType.Int32, direction:ParameterDirection.Input);
            p.Add("Badge_Name", badgeactivity.Badgename, dbType:DbType.String, direction:ParameterDirection.Input);
            p.Add("RowsAffected", dbType:DbType.Int32, direction:ParameterDirection.Output);

            _dbContext.Connection.ExecuteAsync("BadgeActivity_Package.UpdateBadgeActivity",p,commandType:CommandType.StoredProcedure);

            return p.Get<int>("RowsAffected");

        }
    }
}
