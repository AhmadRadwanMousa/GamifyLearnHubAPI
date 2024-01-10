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
	public class CouponRepository : ICouponRepository
	{
		private readonly IDbContext _dbContext;

        public CouponRepository(IDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task<int> CreateCoupon(Coupon coupon)
		{
			var p = new DynamicParameters();
			p.Add("coupon_name", coupon.Couponname, dbType: DbType.String, direction: ParameterDirection.Input);
			p.Add("coupon_percent", coupon.Couponpercent, dbType: DbType.Int32, direction: ParameterDirection.Input);
			p.Add("points", coupon.Points, dbType: DbType.Int32, direction: ParameterDirection.Input);
			p.Add("created_id", dbType: DbType.Int32, direction: ParameterDirection.Output);
			p.Add("rows_affected", dbType: DbType.Int32, direction: ParameterDirection.Output);


			await _dbContext.Connection.ExecuteAsync("Coupon_Package.CreateCoupon",p, commandType:CommandType.StoredProcedure);
			return p.Get<int>("created_id");

		}

		public async Task<int> DeleteCoupon(int id)
		{
			var p = new DynamicParameters();
			p.Add("id", id, dbType: DbType.Int32, direction:ParameterDirection.Input);
			p.Add("deleted_id", dbType: DbType.Int32, direction: ParameterDirection.Output);
			p.Add("rows_affected", dbType: DbType.Int32, direction: ParameterDirection.Output);

			await _dbContext.Connection.ExecuteAsync("Coupon_Package.DeleteCoupon", p, commandType: CommandType.StoredProcedure);
			return p.Get<int>("rows_affected");

		}

		public async Task<List<Coupon>> GetAllCoupons()
		{
			var result = await _dbContext.Connection.QueryAsync<Coupon>("Coupon_Package.GetAllCoupons", commandType: CommandType.StoredProcedure);

			return result.ToList();
		}

		public async Task<Coupon> GetCouponById(int id)
		{
			var p = new DynamicParameters();

			p.Add("id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
			var result = await _dbContext.Connection.QueryAsync<Coupon>("Coupon_Package.GetCouponById", p, commandType: CommandType.StoredProcedure);
			return result.FirstOrDefault();
		}

		public async Task<int> UpdateCoupon(Coupon coupon)
		{
			var p = new DynamicParameters();
			p.Add("id", coupon.Couponid, dbType: DbType.Int32, direction: ParameterDirection.Input);
			p.Add("coupon_name", coupon.Couponname, dbType: DbType.String, direction: ParameterDirection.Input);
			p.Add("coupon_percent", coupon.Couponpercent, dbType: DbType.Int32, direction: ParameterDirection.Input);
			p.Add("new_points", coupon.Points, dbType: DbType.Int32, direction: ParameterDirection.Input);
			//p.Add("updated_id", dbType: DbType.Int32, direction: ParameterDirection.Output);
			p.Add("RowsAffected", dbType: DbType.Int32, direction: ParameterDirection.Output);

			await _dbContext.Connection.ExecuteAsync("Coupon_Package.UpdateCoupon", p, commandType: CommandType.StoredProcedure);

			return p.Get<int>("RowsAffected");
		}
	}
}
