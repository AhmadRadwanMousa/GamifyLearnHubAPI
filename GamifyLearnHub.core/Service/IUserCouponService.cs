using GamifyLearnHub.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyLearnHub.Core.Service
{
	public interface IUserCouponService
	{
		Task<List<Usercoupon>> GetAllUserCoupon();
		Task<Usercoupon> GetUserCouponById(int id);
		Task<int> CreateUserCoupon(Usercoupon userCoupon);
		Task<int> UpdateUserCoupon(Usercoupon userCoupon);
		Task<int> DeleteUserCoupon(int id);
	}
}
