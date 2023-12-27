using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GamifyLearnHub.Attributes;
using GamifyLearnHub.Core.Data;
using GamifyLearnHub.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GamifyLearnHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SectionController : ControllerBase
    {
        private readonly ISectionService _sectionService;

        public SectionController(ISectionService sectionService)
        {
            _sectionService = sectionService ?? throw new ArgumentNullException(nameof(sectionService));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Section>>> GetAllSections()
        {
            try
            {
                var sections = await _sectionService.GetAllSections();
                return Ok(sections);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }

        [HttpGet("{sectionId}")]
        public async Task<ActionResult<Section>> GetSectionById(decimal sectionId)
        {
            try
            {
                var section = await _sectionService.GetSectionById(sectionId);

                if (section == null)
                {
                    return NotFound();
                }

                return Ok(section);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }

        [HttpGet("GetSectionByCourseId/{courseId}")]
        public async Task<List<Section>> GetSectionByCourseId(decimal courseId)
        {

            return await _sectionService.GetSectionByCourseId(courseId);

        }


        [HttpGet("GetAllSectionsByCourseSequenceId/{courseSequenceId}")]
        public async Task<List<Section>> GetAllSectionsByCourseSequenceId(int courseSequenceId)
        {

            return await _sectionService.GetAllSectionsByCourseSequenceId(courseSequenceId);

        }

        [HttpGet("GetAllSectionsByUserId/{userId}")]
        public async Task<List<Section>> GetAllSectionsByUserId(int userId)
        {

            return await _sectionService.GetAllSectionsByUserId(userId);

        }


        [HttpPost]
        public async Task<IActionResult> CreateSection([FromBody] Section section)
        {
            try
            {
                decimal createdSectionId = await _sectionService.CreateSection(section);
                return Ok(new { sectionId = createdSectionId });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }

        [HttpPut("{sectionId}")]
        public async Task<IActionResult> UpdateSection(decimal sectionId, [FromBody] Section section)
        {
            try
            {
                int affectedRows = await _sectionService.UpdateSection(sectionId, section);
                return Ok(new { affectedRows });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }

        [HttpDelete("{sectionId}")]
        public async Task<IActionResult> DeleteSection(decimal sectionId)
        {
            try
            {
                int affectedRows = await _sectionService.DeleteSection(sectionId);
                return Ok(new { affectedRows });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }


        [HttpGet("GetAllUsersWithRoleId2")]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsersWithRoleId2()
        {
            try
            {
                var users = await _sectionService.GetAllUsersWithRoleId2();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }
        [HttpGet]
        [Route("GetSectionsByInstructorId/{instructorId}")]
        [CheckClaims("roleId","2")]
         public async Task<List<Section>>GetSectionByInstructorId(int instructorId)
        {
            return await _sectionService.GetSectionByInstructorId(instructorId);
        }
    }
}
