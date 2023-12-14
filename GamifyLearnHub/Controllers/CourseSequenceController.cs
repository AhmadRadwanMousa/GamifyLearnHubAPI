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
        public CourseSequenceController(ICourseSequenceService courseSequenceService)
        {
            _courseSequenceService = courseSequenceService;
        }





        [HttpGet]
        [CheckClaims("roleId", "1")]
        public async Task<List<Coursesequence>> GetAllCourseSequences()
        {
            return await _courseSequenceService.GetAllCourseSequences();
        }

        [HttpGet]
        [Route("GetById/{id}")]
        [CheckClaims("roleId", "1")]
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
        [CheckClaims("roleId", "1")]
        public async Task<IActionResult> CreateCourseSequence([FromForm]  Coursesequence coursesequence)
        {
            var createdId = await _courseSequenceService.CreateCourseSequence(coursesequence);
            if (createdId != null)
            {
                return Ok(new { CreatedId = createdId });

            }
            else { return BadRequest("Create failed."); }
        }


        [HttpPut]
        [CheckClaims("roleId", "1")]
        public async Task<IActionResult> UpdateCourseSequence([FromForm] Coursesequence coursesequence)

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
        [CheckClaims("roleId", "1")]
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







    }
}
