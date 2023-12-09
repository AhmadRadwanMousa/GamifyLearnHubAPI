using GamifyLearnHub.Core.Data;
using GamifyLearnHub.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GamifyLearnHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    public class UserSectionController : ControllerBase
    {
        private readonly IUserSectionService _userSectionService;

        public UserSectionController(IUserSectionService userSectionService)
        {
            _userSectionService = userSectionService;
        }

        [HttpGet]
        public async Task<IEnumerable<Usersection>> GetAllUserSections()
        {
            return await _userSectionService.GetAllUserSections();
        }

        [HttpGet("{userSectionId}")]
        public async Task<Usersection> GetUserSectionById(decimal userSectionId)
        {
            return await _userSectionService.GetUserSectionById(userSectionId);
        }

        [HttpPost]
        public async Task CreateUserSection(Usersection userSection)
        {
            await _userSectionService.CreateUserSection(userSection);
        }

        [HttpPut("{userSectionId}")]
        public async Task UpdateUserSection(decimal userSectionId, Usersection userSection)
        {
            userSection.Usersectionid = userSectionId;
            await _userSectionService.UpdateUserSection(userSection);
        }

        [HttpDelete("{userSectionId}")]
        public async Task DeleteUserSection(decimal userSectionId)
        {
            await _userSectionService.DeleteUserSection(userSectionId);
        }
    }
}
