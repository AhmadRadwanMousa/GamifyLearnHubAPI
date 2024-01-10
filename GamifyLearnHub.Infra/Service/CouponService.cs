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
	public class CouponService : ICouponService
	{
		private readonly ICouponRepository _couponRepository;
        public CouponService(ICouponRepository couponRepository)
        {
			this._couponRepository = couponRepository;   
        }
        public async Task<int> CreateCoupon(Coupon coupon)
		{
			return await _couponRepository.CreateCoupon(coupon);
		}

		public async Task<int> DeleteCoupon(int id)
		{
			return await _couponRepository.DeleteCoupon(id);
		}

		public async Task<List<Coupon>> GetAllCoupons()
		{
			return await _couponRepository.GetAllCoupons();
		}

		public async Task<Coupon> GetCouponById(int id)
		{
			return await _couponRepository.GetCouponById(id);
		}

		public async Task<int> UpdateCoupon(Coupon coupon)
		{ 
			return await _couponRepository.UpdateCoupon(coupon);
		}
	}
}
