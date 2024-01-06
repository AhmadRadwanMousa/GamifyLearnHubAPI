using GamifyLearnHub.Core.Data;
using GamifyLearnHub.Core.DTO;
using GamifyLearnHub.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GamifyLearnHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserDashboardInfoController : ControllerBase
    {
        private readonly IUserDashboardInfoService _userDashboardInfoService;

        public UserDashboardInfoController(IUserDashboardInfoService userDashboardInfoService)
        {
            _userDashboardInfoService = userDashboardInfoService;
        }

        [HttpGet("UserDashboardInfoByUserId/{id}")]
        public async Task<UserDashboarInfo> UserDashboardInfoByUserId(int id) 
        { 
            return await _userDashboardInfoService.UserDashboardInfoByUserId(id);
        }

        [HttpGet("UserDashboardAttendence/{userid:int}/{sectionid:int}")]
        public async Task<List<Attendence>> UserDashboardAttendence(decimal userid, decimal sectionid)
        {
            return await _userDashboardInfoService.UserDashboardAttendence(userid, sectionid);
        }

        [HttpGet("CompletedCourses/{id}")]
        public async Task<List<CompletedCourses>> CompletedCourses(int id)
        {
            return await _userDashboardInfoService.CompletedCoursesByUserId(id);
        }

    }
}
