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
using static Azure.Core.HttpHeader;

namespace GamifyLearnHub.Infra.Repositroy
{
	public class UserCouponRepository : IUserCouponRepository
	{
		private readonly IDbContext _dbContext;

        public UserCouponRepository(IDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task<int> CreateUserCoupon(Usercoupon userCoupon)
		{
			var p = new DynamicParameters();
			p.Add("user_id", userCoupon.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
			p.Add("coupon_id", userCoupon.Couponid, dbType: DbType.Int32, direction: ParameterDirection.Input);
			p.Add("date_earned", userCoupon.Dateearned, dbType: DbType.DateTime, direction: ParameterDirection.Input);
			p.Add("is_used", userCoupon.Isused , dbType: DbType.Int32, direction: ParameterDirection.Input);
			p.Add("CreatedId", dbType: DbType.Int32, direction: ParameterDirection.Output);


			await _dbContext.Connection.ExecuteAsync("UserCoupon_Package.CreateUserCoupon", p, commandType: CommandType.StoredProcedure);
			return p.Get<int>("CreatedId");
		}

		public async Task<int> DeleteUserCoupon(int id)
		{
			var p = new DynamicParameters();
			p.Add("id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
			p.Add("RowsAffected", dbType: DbType.Int32, direction: ParameterDirection.Output);

			await _dbContext.Connection.ExecuteAsync("UserCoupon_Package.DeleteUserCoupon", p, commandType: CommandType.StoredProcedure);
			return p.Get<int>("RowsAffected");
		}

		public async Task<List<Usercoupon>> GetAllUserCoupon()
		{
			var result = await _dbContext.Connection.QueryAsync<Usercoupon>("UserCoupon_Package.GetAllUserCoupons", commandType: CommandType.StoredProcedure);

			return result.ToList();
		}

		public async Task<Usercoupon> GetUserCouponById(int id)
		{
			var p = new DynamicParameters();

			p.Add("id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
			var result = await _dbContext.Connection.QueryAsync<Usercoupon>("UserCoupon_Package.GetUserCouponById", p, commandType: CommandType.StoredProcedure);
			return result.FirstOrDefault();
		}

		public async Task<int> UpdateUserCoupon(Usercoupon userCoupon)
		{
			var p = new DynamicParameters();
			p.Add("id", userCoupon.Usercouponid, dbType: DbType.Int32, direction: ParameterDirection.Input);
			p.Add("user_id", userCoupon.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
			p.Add("coupon_id", userCoupon.Couponid, dbType: DbType.Int32, direction: ParameterDirection.Input);
			p.Add("date_earned", userCoupon.Dateearned, dbType: DbType.DateTime, direction: ParameterDirection.Input);
			p.Add("is_used", userCoupon.Isused, dbType: DbType.Int32, direction: ParameterDirection.Input);
			p.Add("RowsAffected", dbType: DbType.Int32, direction: ParameterDirection.Output);

			await _dbContext.Connection.ExecuteAsync("UserCoupon_Package.UpdateUserCoupon", p, commandType: CommandType.StoredProcedure);

			return p.Get<int>("RowsAffected");
		}
	}
}
