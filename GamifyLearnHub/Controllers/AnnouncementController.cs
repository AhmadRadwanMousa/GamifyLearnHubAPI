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
    public class AnnouncementController : ControllerBase
    {
        private readonly IAnnouncementService  _announcementService ;
        public AnnouncementController(IAnnouncementService announcementService)
        {
            this._announcementService = announcementService;
        }

        [HttpGet]
        public async Task<List<Announcement>> GetAllAnnouncements()
        {
            return await _announcementService.GetAllAnnouncements();
        }

        [HttpPost]
        //[CheckClaims("roleId", "2")]
        public async Task<int> CreateAnnouncement([FromBody] Announcement announcement)
        {
            return await _announcementService.CreateAnnouncement(announcement);
        }

        [HttpPut]
        //[CheckClaims("roleId", "2")]
        public async Task<int> UpdateAnnouncement([FromBody] Announcement announcement)
        {
            return await _announcementService.UpdateAnnouncement(announcement);
        }

        [HttpDelete("{id}")]
        //[CheckClaims("roleId", "2")]
        public async Task<int> DeleteAnnouncement(int id)
        {
            return await _announcementService.DeleteAnnouncement(id);
        }

        [HttpGet]
        [Route("GetAnnouncementById/{id}")]
        public async Task<Announcement> GetAnnouncementById(int id)
        {
            return await _announcementService.GetAnnouncementById(id);
        }

        [HttpGet]
        [Route("GetAnnouncementsBySectionId/{id}")]
        public async Task<List<Announcement>> GetAnnouncementsBySectionId(int id)
        {
            return await _announcementService.GetAnnouncementsBySectionId(id);
        }

    }
}
