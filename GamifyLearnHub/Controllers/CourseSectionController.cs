using GamifyLearnHub.Attributes;
using GamifyLearnHub.Core.Data;
using GamifyLearnHub.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GamifyLearnHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseSectionController : ControllerBase
    {
        private readonly ICourseSectionService _courseSectionService;

        public CourseSectionController(ICourseSectionService courseSectionService)
        {
            _courseSectionService = courseSectionService;
        }

        [HttpGet]
        public async Task<IEnumerable<Coursesection>> GetAllCourseSections()
        {
            return await _courseSectionService.GetAllCourseSections();
        }

        [HttpGet("{courseSectionId}")]
        public async Task<Coursesection> GetCourseSectionById(decimal courseSectionId)
        {
            return await _courseSectionService.GetCourseSectionById(courseSectionId);
        }

        [HttpPost]
        [CheckClaims("roleId", "2")]
        public async Task<ActionResult<decimal>> CreateCourseSection(Coursesection courseSection)
        {
            decimal createdId = await _courseSectionService.CreateCourseSection(courseSection);
            return CreatedAtAction(nameof(GetCourseSectionById), new { courseSectionId = createdId }, createdId);
        }

        [HttpPut("{courseSectionId}")]
        [CheckClaims("roleId", "2")]

        public async Task<IActionResult> UpdateCourseSection(decimal courseSectionId, Coursesection courseSection)
        {
            courseSection.Coursesectionid = courseSectionId;
            int affectedRows = await _courseSectionService.UpdateCourseSection(courseSection);

            return affectedRows > 0
                ? Ok(new { affectedRows })
                : NotFound(new { affectedRows });
        }

        [HttpDelete("{courseSectionId}")]
        [CheckClaims("roleId", "2")]
        public async Task<IActionResult> DeleteCourseSection(decimal courseSectionId)
        {
            try
            {
                int affectedRows = await _courseSectionService.DeleteCourseSection(courseSectionId);
                return Ok(new { affectedRows });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }


        [HttpGet("GetCoursesSectionBySectionId/{sectionId}")]
        public async Task<List<Coursesection>> GetCoursesSectionBySectionId(int sectionId)
        {
            return await _courseSectionService.GetCoursesSectionBySectionId(sectionId);
        }

        

    }
}
