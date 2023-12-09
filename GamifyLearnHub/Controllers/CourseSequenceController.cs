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
        public async Task<List<Coursesequence>> GetAllCourseSequences()
        {
            return await _courseSequenceService.GetAllCourseSequences();
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<Coursesequence> GetCourseSequenceById(int id)
        {
            return await _courseSequenceService.GetCourseSequenceById(id);
        }



        [HttpPost]
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
