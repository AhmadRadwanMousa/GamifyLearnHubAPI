
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Threading.Tasks;
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
        public ActionResult<IEnumerable<Section>> GetAllSections()
        {
            try
            {
                var sections = _sectionService.GetAllSections();
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

        [HttpPost]
        public async Task<IActionResult> CreateSection([FromBody] Section section)
        {
            try
            {
                await _sectionService.CreateSection(section);
                return CreatedAtAction(nameof(GetSectionById), new { sectionId = section.Sectionid }, section);
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
                var existingSection = await _sectionService.GetSectionById(sectionId);

                if (existingSection == null)
                {
                    return NotFound();
                }

                section.Sectionid = sectionId;
                await _sectionService.UpdateSection(section);

                return Ok(section);
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
                var existingSection = await _sectionService.GetSectionById(sectionId);

                if (existingSection == null)
                {
                    return NotFound();
                }

                await _sectionService.DeleteSection(sectionId);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }
    }
}
