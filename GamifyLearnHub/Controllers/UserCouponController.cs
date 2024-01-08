using GamifyLearnHub.Core.Data;
using GamifyLearnHub.Core.Service;
using GamifyLearnHub.Infra.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GamifyLearnHub.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserCouponController : ControllerBase
	{
		private readonly IUserCouponService _userCouponService;
        public UserCouponController(IUserCouponService userCouponService)
        {
            this._userCouponService = userCouponService;
        }

		[HttpGet]
		[Route("GetAllUserCoupon")]
		public async Task<List<Usercoupon>> GetAllCoupons()
		{
			return await _userCouponService.GetAllUserCoupon();
		}
		[HttpGet]
		[Route("GetAllUserCouponsByUserId/{userId}")]
		public async Task<List<Usercoupon>>GetAllUserCouponsByUserId(int userId)
		{
			return await _userCouponService.GetAllUserCoupons(userId);
		}
		[HttpPost]
		[Route("CreateUserCoupon")]
		public async Task<int> CreateUserCoupon([FromForm] Usercoupon userCoupon)
		{
			return await _userCouponService.CreateUserCoupon(userCoupon);
		}
		[HttpPut]
		[Route("UpdateUserCoupon")]
		public async Task<int> UpdateUserCoupon([FromForm] Usercoupon userCoupon)
		{
			return await _userCouponService.UpdateUserCoupon(userCoupon);
		}
		[HttpDelete("{id}")]
		public async Task<int> DeleteUserCoupon(int id)
		{
			return await _userCouponService.DeleteUserCoupon(id);
		}
		[HttpGet]
		[Route("GetUserCouponById/{id}")]
		public async Task<Usercoupon> GetUserCouponById(int id)
		{
			return await _userCouponService.GetUserCouponById(id);
		}
		[HttpGet]
		[Route("GetUserCouponByUserIdAndCouponName/{userId}/{couponName}")]
		public async Task<Usercoupon>GetUserCouponByNameAndUserId(int userId, string couponName)
		{
			return await _userCouponService.GetCouponByNameAndUserId(couponName, userId);	
		}
		[HttpPut("{userCouponId}")]

		public async Task<int> UpdateUserCoupon(int userCouponId)
		{
			return await _userCouponService.UpdateUserCouponStatus(userCouponId);	
		}

	}
}
