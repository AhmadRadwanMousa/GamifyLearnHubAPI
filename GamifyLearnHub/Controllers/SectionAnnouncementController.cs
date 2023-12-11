using GamifyLearnHub.Core.Data;
using GamifyLearnHub.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GamifyLearnHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SectionAnnouncementController : ControllerBase
    {
        private readonly ISectionAnnouncementService _sectionAnnouncementService;

        public SectionAnnouncementController(ISectionAnnouncementService sectionAnnouncementService)
        {
            _sectionAnnouncementService = sectionAnnouncementService;
        }

        [HttpGet]
        public async Task<IEnumerable<Sectionannoncment>> GetAllSectionAnnouncements()
        {
            return await _sectionAnnouncementService.GetAllSectionAnnouncements();
        }

        [HttpGet("{announcementId}")]
        public async Task<Sectionannoncment> GetSectionAnnouncementById(decimal announcementId)
        {
            return await _sectionAnnouncementService.GetSectionAnnouncementById(announcementId);
        }

        [HttpPost]
        public async Task<ActionResult<decimal>> CreateSectionAnnouncement(Sectionannoncment sectionAnnouncement)
        {
            decimal createdId = await _sectionAnnouncementService.CreateSectionAnnouncement(sectionAnnouncement);
            return CreatedAtAction(nameof(GetSectionAnnouncementById), new { announcementId = createdId }, createdId);
        }

        [HttpPut("{announcementId}")]
        public async Task<IActionResult> UpdateSectionAnnouncement(decimal announcementId, Sectionannoncment sectionAnnouncement)
        {
            sectionAnnouncement.Sectionannoncmentid = announcementId;
            int affectedRows = await _sectionAnnouncementService.UpdateSectionAnnouncement(sectionAnnouncement);

            return affectedRows > 0
                ? Ok(new { affectedRows })
                : NotFound(new { affectedRows });
        }

        [HttpDelete("{announcementId}")]
        public async Task<IActionResult> DeleteSectionAnnouncement(decimal announcementId)
        {
            try
            {
                int affectedRows = await _sectionAnnouncementService.DeleteSectionAnnouncement(announcementId);
                return Ok(new { affectedRows });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }
    }
}
