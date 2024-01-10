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
        private readonly IUserService _userService;
        
        public AdminLeaderBoardController(IAdminLeaderBoardService adminLeaderBoardService, IUserService userService)
        {
            _adminLeaderBoardService = adminLeaderBoardService;
            _userService = userService;
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

        [HttpGet("InstructorLectures/{id}")]
        public async Task<int> InstructorLectures(int id)
        {
            return await _adminLeaderBoardService.InstructorLectures(id);
        }

        [HttpGet("InstructorPointsStudents/{id}")]
        public async Task<List<RankByPoints>> InstructorPointsStudents(int id)
        {
            return await _adminLeaderBoardService.RankByPointsInstructorStudents(id);
        }

        [HttpGet("InstructorName/{id}")]
        public async Task<InstructorNameResponse> InstructorName(int id)
        {
            var result = await _userService.GetUserById(id);
            var firstName = result.Firsname;
            var lastName = result.Lastname;
            var fullName = $"{firstName} {lastName}";

            return new InstructorNameResponse { FullName = fullName };
        }

        [HttpGet("InstructorPointsStudents2")]
        public async Task<List<RankByPoints>> InstructorPointsStudents2()
        {
            return await _adminLeaderBoardService.RankByPointsInstructorStudents2();
        }

    }
}
