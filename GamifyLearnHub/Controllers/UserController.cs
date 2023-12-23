using GamifyLearnHub.Core.Data;
using GamifyLearnHub.Core.DTO;
using GamifyLearnHub.Core.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GamifyLearnHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<int> CreateUser([FromBody] UserDetails? userDetails)
        {
            return await _userService.CreateUser(userDetails);
        }
        [HttpDelete("{userId}")]
        public async Task<int>DeleteUser (int userId)
        {
           return await _userService.DeleteUser(userId);  
        }
        [HttpPut]
        //[Authorize]
        public async Task<int> UpdateUser([FromBody]UserDetails ?userDetails)
        {
            return await _userService.UpdateUser(userDetails);
        }
        [HttpPut]
        [Route("EditProfile")]
        public async Task<int> EditUserProfile([FromBody] UserDetails ?userDetails)
        {
            return await _userService.EditUserProfile(userDetails); 
        }
        [HttpGet]
        public async Task<List<User>> GetAllUsers()
        {
            return await _userService.GetAllUsers();
        }
        

        [HttpGet("{userId}")]
        public async Task<User> GetUserById(int userId)
        {
            return await _userService.GetUserById(userId);
        }
    }
}
