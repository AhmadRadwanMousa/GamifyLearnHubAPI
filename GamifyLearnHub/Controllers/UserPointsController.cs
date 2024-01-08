using GamifyLearnHub.Core.Data;
using GamifyLearnHub.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GamifyLearnHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserPointsController : ControllerBase
    {
        private readonly IUserPointsService _userPointsService;
        public UserPointsController(IUserPointsService userPointsService)
        {
            _userPointsService = userPointsService;
        }
        [HttpGet("{userId}")]
        public async Task<List<Userpointsactivity>>GetAllUnviewedUserPoints(int userId)
        {
            return await _userPointsService.GetAllUnViewedUserPoints(userId);   
        }
        [HttpPut("{userPointsId}")]
        public async Task<int> UpdateUserPointsState(int userPointsId)
        {
            return await _userPointsService.UpdateUserPointsState(userPointsId);  
        }
        
    }
}
