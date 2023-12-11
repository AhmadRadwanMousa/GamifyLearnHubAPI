using GamifyLearnHub.Core.Data;
using GamifyLearnHub.Core.Service;
using GamifyLearnHub.Infra.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GamifyLearnHub.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CouponController : ControllerBase
	{
		private readonly ICouponService _couponService;
        public CouponController(ICouponService couponService)
        {
            this._couponService = couponService;
        }
		[HttpGet]
		[Route("GetAllCoupons")]
		public async Task<List<Coupon>> GetAllCoupons()
		{
			return await _couponService.GetAllCoupons();
		}
		[HttpPost]
		[Route("CreateCoupon")]
		public async Task<int> CreateCoupon([FromForm] Coupon coupon)
		{
			return await _couponService.CreateCoupon(coupon);
		}
		[HttpPut]
		[Route("UpdateCoupon")]
		public async Task<int> UpdateCoupon([FromForm] Coupon coupon)
		{
			return await _couponService.UpdateCoupon(coupon);
		}
		[HttpDelete("{id}")]
		public async Task<int> DeleteCoupon(int id)
		{
			return await _couponService.DeleteCoupon(id);
		}
		[HttpGet]
		[Route("GetCouponById/{id}")]
		public async Task<Coupon> GetCouponById(int id)
		{
			return await _couponService.GetCouponById(id);
		}
	}
}
