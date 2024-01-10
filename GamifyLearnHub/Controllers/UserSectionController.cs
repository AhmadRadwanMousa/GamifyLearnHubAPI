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

        [HttpGet("GetAllUserSectionsBySectionId/{id}")]
        public async Task<IEnumerable<Usersection>> GetAllUserSectionsBySectionId(int id)
        {
            var result =  await _userSectionService.GetAllUserSections();
            return result.Where(s=> s.Sectionid == id).ToList();
        }

        [HttpGet("GetAllStudentsUsers")]
        public async Task<List<User>> GetAllStudentsUsers() {
            return await _userSectionService.GetAllUserStudents();
        }

      

        [HttpGet("{userSectionId}")]
        public async Task<Usersection> GetUserSectionById(decimal userSectionId)
        {
            return await _userSectionService.GetUserSectionById(userSectionId);
        }

        [HttpPost]
        public async Task<ActionResult<decimal>> CreateUserSection(Usersection userSection)
        {
            userSection.Enrollmentdate = DateTime.Now;
            userSection.Studentmark = 0;
            decimal createdId = await _userSectionService.CreateUserSection(userSection);
            return CreatedAtAction(nameof(GetUserSectionById), new { userSectionId = createdId }, createdId);
        }

        [HttpPut("{userSectionId}")]
        public async Task<IActionResult> UpdateUserSection(decimal userSectionId, Usersection userSection)
        {
            userSection.Usersectionid = userSectionId;
            int affectedRows = await _userSectionService.UpdateUserSection(userSection);

            return affectedRows > 0
                ? Ok(new { affectedRows })
                : NotFound(new { affectedRows });
        }

        [HttpDelete("{userSectionId}")]
        public async Task<IActionResult> DeleteUserSection(decimal userSectionId)
        {
            try
            {
                int affectedRows = await _userSectionService.DeleteUserSection(userSectionId);
                return Ok(new { affectedRows });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }

        [HttpGet("GetUserSectionsBySectionId/{sectionId}")]
        public async Task<IEnumerable<Usersection>> GetUserSectionsBySectionId(decimal sectionId)
        {
            return await _userSectionService.GetUserSectionsBySectionId(sectionId);
        }

        [HttpGet("GetUsersBySectionId/{sectionId}")]
        public async Task<IEnumerable<User>> GetUsersBySectionId(decimal sectionId)
        {
            return await _userSectionService.GetUsersBySectionId(sectionId);
        }
        [HttpPut]
        [Route("SetAssignmentMark")]
        public async Task<int> SetAssignmentMark([FromForm] int studentId, [FromForm] int assignmentId , [FromForm] int mark)
        {
            return await _userSectionService.SetUserAssignmentMark(mark,assignmentId, studentId);   
        }
    }





}
