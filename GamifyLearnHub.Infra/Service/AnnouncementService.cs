using GamifyLearnHub.Core.Data;
using GamifyLearnHub.Core.Repository;
using GamifyLearnHub.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyLearnHub.Infra.Service
{
    public class AnnouncementService : IAnnouncementService
    {
        private readonly IAnnouncementRepository _announcementRepository;

        public AnnouncementService(IAnnouncementRepository announcementRepository)
        {
            _announcementRepository = announcementRepository;
        }



        public async Task<int> CreateAnnouncement(Announcement announcement)
        {
           return await _announcementRepository.CreateAnnouncement(announcement);
        }

        public async Task<int> DeleteAnnouncement(int id)
        {
            return await _announcementRepository.DeleteAnnouncement(id);
        }

        public async Task<List<Announcement>> GetAllAnnouncements()
        {
            return await _announcementRepository.GetAllAnnouncements();
        }

        public async Task<Announcement> GetAnnouncementById(int id)
        {
            return await _announcementRepository.GetAnnouncementById(id);
        }

        public async Task<List<Announcement>> GetAnnouncementsBySectionId(int sectionId)
        {
            return await _announcementRepository.GetAnnouncementsBySectionId(sectionId);
        }

        public async Task<int> UpdateAnnouncement(Announcement announcement)
        {
            return await _announcementRepository.UpdateAnnouncement(announcement);
        }
    }
}
