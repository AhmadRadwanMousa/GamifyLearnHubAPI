using GamifyLearnHub.Core.Data;
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
        public async Task<List<Badgeactivity>> GetAll()
        {
            return await _badgeActivityService.GetAll();
        }

        [HttpPut]
        public async Task<int> UpdateBadgeActivity(Badgeactivity badgeactivity)
        {
            return await _badgeActivityService.UpdateBadgeActivity(badgeactivity);
        }
    }
}
