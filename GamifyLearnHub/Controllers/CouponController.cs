using GamifyLearnHub.Attributes;
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
        [CheckClaims("roleId", "1")]
        public async Task<List<Coupon>> GetAllCoupons()
		{
			return await _couponService.GetAllCoupons();
		}
		[HttpPost]
		[Route("CreateCoupon")]
        [CheckClaims("roleId", "1")]
        public async Task<int> CreateCoupon( Coupon coupon)
		{
			return await _couponService.CreateCoupon(coupon);
		}
		[HttpPut]
		[Route("UpdateCoupon")]
        [CheckClaims("roleId", "1")]
        public async Task<int> UpdateCoupon( Coupon coupon)
		{
			return await _couponService.UpdateCoupon(coupon);
		}
		[HttpDelete("{id}")]
        [CheckClaims("roleId", "1")]
        public async Task<int> DeleteCoupon(int id)
		{
			return await _couponService.DeleteCoupon(id);
		}
		[HttpGet]
		[Route("GetCouponById/{id}")]
        [CheckClaims("roleId", "1")]
        public async Task<Coupon> GetCouponById(int id)
		{
			return await _couponService.GetCouponById(id);
		}
	}
}
