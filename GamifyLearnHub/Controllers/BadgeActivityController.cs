using GamifyLearnHub.Attributes;
using GamifyLearnHub.Core.Data;
using GamifyLearnHub.Core.DTO;
using GamifyLearnHub.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GamifyLearnHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BadgeActivityController : ControllerBase
    {
        private readonly IBadgeActivityService _badgeActivityService;

        public BadgeActivityController(IBadgeActivityService badgeActivityService)
        {
            _badgeActivityService = badgeActivityService;
        }

        [HttpGet]
        [CheckClaims("roleId", "1")]

        public async Task<List<Badgeactivity>> GetAll()
        {
            return await _badgeActivityService.GetAll();
        }

        [HttpPut]
        [CheckClaims("roleId", "1")]

        public async Task<int> UpdateBadgeActivity(Badgeactivity badgeactivity)
        {
            return await _badgeActivityService.UpdateBadgeActivity(badgeactivity);
        }
        [HttpGet("{userId}")]
        public async Task<List<Userbadgeactivity>> GetAllUserBadgesByUserId(int userId)
        {
            return await _badgeActivityService.GetUserBadgesByUserId(userId);
        }

        [HttpGet]
        [Route("UnviewedUserBadges/{userId}")]
        public async Task<List<Userbadgeactivity>> GetAllUnViewedUserBadges(int userId) {
            return await _badgeActivityService.GetAllUnviewedUserBadges(userId);
        }
        [HttpPut]
        [Route("UpdateUserBadgeStatus")]
        public async Task<int> UpdateUserBadgeStatus ([FromBody]UpdateUserBadgeDetails userbadgedetails)
        {
            return await _badgeActivityService.UpdateUserBadgeStatus(userbadgedetails);     
        }
    }
}
