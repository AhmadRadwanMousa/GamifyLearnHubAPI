using GamifyLearnHub.Core.DTO;
using GamifyLearnHub.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GamifyLearnHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminLeaderBoardController : ControllerBase
    {
        private readonly IAdminLeaderBoardService _adminLeaderBoardService;
        public AdminLeaderBoardController(IAdminLeaderBoardService adminLeaderBoardService)
        {
            _adminLeaderBoardService = adminLeaderBoardService;
        }

        [HttpGet("ByBadges")]
        public async Task<List<RankByBadges>> ByBadges() 
        { 
            return await _adminLeaderBoardService.RankByBadgesStudents();
        }

        [HttpGet("ByPoints")]
        public async Task<List<RankByPoints>> ByPoints()
        {
            return await _adminLeaderBoardService.RankByPointsStudents();
        }

        [HttpGet("Statistics")]
        public async Task<List<AdminStatistics>> Statistics()
        {
            return await _adminLeaderBoardService.AdminStatistics();
        }

        [HttpGet("InstructorStudents/{id}")]
        public async Task<int> InstructorStudents(int id)
        {
            return await _adminLeaderBoardService.InstructorStudents(id);
        }

        [HttpGet("InstructorPointsStudents/{id}")]
        public async Task<List<RankByPoints>> InstructorPointsStudents(int id)
        {
            return await _adminLeaderBoardService.RankByPointsInstructorStudents(id);
        }
    }
}
