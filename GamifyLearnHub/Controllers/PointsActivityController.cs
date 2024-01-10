using GamifyLearnHub.Attributes;
using GamifyLearnHub.Core.Data;
using GamifyLearnHub.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GamifyLearnHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PointsActivityController : ControllerBase
    {
        private readonly IPointsActivityService _pointsActivityService;

        public PointsActivityController(IPointsActivityService pointsActivityService)
        {
            _pointsActivityService = pointsActivityService;
        }

        [HttpGet]

        public async Task<List<Pointsactivity>> GetAll()
        {
            return await _pointsActivityService.GetAll();
        }

        [HttpPut]
        [CheckClaims("roleId", "1")]
        public async Task<int> UpdatePointsActivity(Pointsactivity pointsactivity)
        {
            return await _pointsActivityService.UpdatePointsActivity(pointsactivity);
        }

        [HttpPost]
        [CheckClaims("roleId", "1")]
        public async Task<int> CreateNewPointsActivity(Pointsactivity pointsactivity)
        {
            return await _pointsActivityService.CreateNewPointsActivity(pointsactivity);
        }

        [HttpDelete("{id}")]
        [CheckClaims("roleId", "1")]
        public async Task<int> DeletePointsActivity(int id)
        {
            return await _pointsActivityService.DeletePointsActivity(id);
        }
    }
}
