using GamifyLearnHub.Core.Data;
using GamifyLearnHub.Core.Repository;
using GamifyLearnHub.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyLearnHub.Infra.Service
{
	public class UserCouponService : IUserCouponService
	{
		private readonly IUserCouponRepository _userCouponRepository;
        public UserCouponService(IUserCouponRepository userCouponRepository)
        {
            this._userCouponRepository = userCouponRepository;
        }
        public async Task<int> CreateUserCoupon(Usercoupon userCoupon)
		{
			return await _userCouponRepository.CreateUserCoupon(userCoupon);
		}

		public async Task<int> DeleteUserCoupon(int id)
		{
			return await _userCouponRepository.DeleteUserCoupon(id);
		}

		public async Task<List<Usercoupon>> GetAllUserCoupon()
		{
			return await _userCouponRepository.GetAllUserCoupon();
		}

		public async Task<Usercoupon> GetUserCouponById(int id)
		{
			return await _userCouponRepository.GetUserCouponById(id);
		}

		public async Task<int> UpdateUserCoupon(Usercoupon userCoupon)
		{
			return await _userCouponRepository.UpdateUserCoupon(userCoupon);
		}
	}
}
