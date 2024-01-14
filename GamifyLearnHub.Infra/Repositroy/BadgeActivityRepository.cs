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

        public async Task<List<Userbadgeactivity>> GetAllUnviewedUserBadges(int userId)
        {
            var p = new DynamicParameters();
            p.Add("user_id", userId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = await _dbContext.Connection.QueryAsync<Userbadgeactivity, Badgeactivity, Userbadgeactivity>
                ("UserBadgeActivity_Package.GetAllUnviewedUserBadges", (userBadge, badge) => 
                {
                 userBadge.Badgeactivity = badge;
                 return userBadge;
                }
                ,p, splitOn: "badgeactivityid", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<List<Userbadgeactivity>> GetUserBadgesByUserId(int userId)
        {
            var p = new DynamicParameters();
            p.Add("user_id", userId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = await _dbContext.Connection.QueryAsync<Userbadgeactivity, Badgeactivity, Userbadgeactivity>
                ("UserBadgeActivity_Package.GetUserBadgesByUserID",
                (userbadge, badge) =>
                {
                    userbadge.Badgeactivity = badge;
                    return userbadge;
                }, p, splitOn: "badgeactivityid");
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
			//p.Add("updated_id", dbType: DbType.Int32, direction: ParameterDirection.Output);


			await _dbContext.Connection.ExecuteAsync("BadgeActivity_Package.UpdateBadgeActivity", p,commandType:CommandType.StoredProcedure);

            return p.Get<int>("RowsAffected");

        }

        public async Task<int> UpdateUserBadgeStatus(int userBadgeId)
        {
            var p = new DynamicParameters();
            p.Add("userBadge_id",userBadgeId, dbType:DbType.Int32, direction: ParameterDirection.Input);    
            p.Add("rows_effected",dbType:DbType.Int32,direction:ParameterDirection.Output);
            await _dbContext.Connection.ExecuteAsync("UserBadgeActivity_Package.UpdateUserBadgeStatus",p,commandType:CommandType.StoredProcedure);
            return p.Get<int>("rows_effected");
        }
    }
}
