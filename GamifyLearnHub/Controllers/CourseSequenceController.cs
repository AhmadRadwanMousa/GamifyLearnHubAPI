using GamifyLearnHub.Attributes;
using GamifyLearnHub.Core.Data;
using GamifyLearnHub.Core.Service;
using GamifyLearnHub.Infra.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GamifyLearnHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseSequenceController : ControllerBase
    {
        private readonly ICourseSequenceService _courseSequenceService;
        private readonly ISectionService _sectionService;
        private readonly IUserSectionService _userSectionService;


        public CourseSequenceController(ICourseSequenceService courseSequenceService, ISectionService sectionService, IUserSectionService userSectionService)
        {
            _courseSequenceService = courseSequenceService;
            _sectionService = sectionService;
            _userSectionService = userSectionService;
        }





        [HttpGet]
        //[CheckClaims("roleId", "1")]
        public async Task<List<Coursesequence>> GetAllCourseSequences()
        {
            return await _courseSequenceService.GetAllCourseSequences();
        }

        [HttpGet]
        [Route("GetById/{id}")]
        //[CheckClaims("roleId", "1")]
        public async Task<Coursesequence> GetCourseSequenceById(int id)
        {
            return await _courseSequenceService.GetCourseSequenceById(id);
        }

        [HttpGet]
        [Route("GetByProgramId/{programId}")]
        public async Task<List<Coursesequence>> GetCourseSequenceByProgramId(int programId)
        {
            return await _courseSequenceService.GetCoursesSequenceByProgramId(programId);
        }



        [HttpPost]
        //[CheckClaims("roleId", "1")]
        public async Task<IActionResult> CreateCourseSequence([FromBody]  Coursesequence coursesequence)
        {
            var createdId = await _courseSequenceService.CreateCourseSequence(coursesequence);
            if (createdId != null)
            {
                return Ok(new { CreatedId = createdId });

            }
            else { return BadRequest("Create failed."); }
        }


        [HttpPut]
        //[CheckClaims("roleId", "1")]
        public async Task<IActionResult> UpdateCourseSequence([FromBody] Coursesequence coursesequence)

        {
            var rowsAffected = await _courseSequenceService.UpdateCourseSequence(coursesequence);

            if (rowsAffected > 0)
            {
                return Ok(new { RowsAffected = rowsAffected });
            }
            else
            {
                return BadRequest("Update failed. Role not found or no changes made.");
            }
        }



        [HttpDelete("{id}")]
        //[CheckClaims("roleId", "1")]
        public async Task<IActionResult> DeleteCourseSequence(int id)
        {
            var rowsAffected = await _courseSequenceService.DeleteCourseSequence(id);

            if (rowsAffected > 0)
            {
                return Ok(new { RowsAffected = rowsAffected });
            }
            else
            {
                return BadRequest("Delete failed. Role not found or some thing wrong.");
            }

        }

        [HttpGet("GetSectionByCourseSequenceId/{courseSequenceId}/{userId}")]
        public async Task<int> GetSectionByCourseSequenceId(int courseSequenceId, int userId)
        {
            var sections = await _sectionService.GetAllSectionsByCourseSequenceId(courseSequenceId);
            var userSections = await _userSectionService.GetAllUserSections();
            var userSectionForUser = userSections.Where(u => u.Userid == userId);
            int sectionId = 0;

            foreach (var section in sections) 
            {
                foreach(var usersection in userSectionForUser) 
                {
                    if (usersection.Sectionid == section.Sectionid) 
                    {
                        sectionId = (int)section.Sectionid;
                    }
                }
            }

            return sectionId;
        }



    }
}
