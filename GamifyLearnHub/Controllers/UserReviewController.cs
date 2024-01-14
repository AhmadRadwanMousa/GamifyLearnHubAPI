using GamifyLearnHub.Core.Data;
using GamifyLearnHub.Core.Service;
using GamifyLearnHub.Infra.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GamifyLearnHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserReviewController : ControllerBase
    {
        private readonly IUserReviewService _userReviewService;

        public UserReviewController(IUserReviewService userReviewService)
        {
            _userReviewService = userReviewService;
        }

        [HttpGet]
        public async Task<List<Userreview>> GetAllUserReviews()
        {
            return await _userReviewService.GetAllUserReviews();
        }

        [HttpGet("{id}")]
        public async Task<Userreview> GetUserReviewsById(int id)
        {
            return await _userReviewService.GetUserReviewById(id);
        }

        [HttpPost]
        public async Task<int> CreateUserReview(Userreview userReview)
        {
            return await _userReviewService.CreateUserReview(userReview);
        }

        [HttpPut]
        public async Task<int> UpdateUserReview([FromBody] Userreview userReview)
        {
            return await _userReviewService.UpdateUserReview(userReview);
        }

        [HttpDelete("{id}")]
        public async Task<int> DeleteUserReview(int id)
        {
            return await _userReviewService.DeleteUserReview(id);
        }

        [HttpGet("finished-programs/{userId}")]
        public async Task<IActionResult> GetFinishedPrograms(int userId)
        {
            
            var finishedPrograms = await _userReviewService.GetFinishedPrograms(userId);
            
            if (finishedPrograms.Count > 0)
            {
                return Ok(finishedPrograms);
            }
            else
            {
                return NotFound(0);
            }
            
            
        }

    }
}
