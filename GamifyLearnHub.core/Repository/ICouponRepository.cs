using GamifyLearnHub.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyLearnHub.Core.Repository
{
	public interface ICouponRepository
	{
		Task<List<Coupon>> GetAllCoupons();
		Task<Coupon> GetCouponById(int id);
		Task<int> CreateCoupon(Coupon coupon);
		Task<int> UpdateCoupon(Coupon coupon);
		Task<int> DeleteCoupon(int id);
	}
}
