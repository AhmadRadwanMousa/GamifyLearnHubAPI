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
    public class SectionAnnouncementService : ISectionAnnouncementService
    {
        private readonly ISectionAnnouncementRepository _sectionAnnouncementRepository;

        public SectionAnnouncementService(ISectionAnnouncementRepository sectionAnnouncementRepository)
        {
            _sectionAnnouncementRepository = sectionAnnouncementRepository;
        }

        public Task<IEnumerable<Sectionannoncment>> GetAllSectionAnnouncements()
        {
            return _sectionAnnouncementRepository.GetAllSectionAnnouncements();
        }

        public Task<Sectionannoncment> GetSectionAnnouncementById(decimal announcementId)
        {
            return _sectionAnnouncementRepository.GetSectionAnnouncementById(announcementId);
        }

        public async Task<decimal> CreateSectionAnnouncement(Sectionannoncment sectionAnnouncement)
        {
            return await _sectionAnnouncementRepository.CreateSectionAnnouncement(sectionAnnouncement);
        }

        public async Task<int> UpdateSectionAnnouncement(Sectionannoncment sectionAnnouncement)
        {
            return await _sectionAnnouncementRepository.UpdateSectionAnnouncement(sectionAnnouncement);
        }

        public async Task<int> DeleteSectionAnnouncement(decimal announcementId)
        {
            return await _sectionAnnouncementRepository.DeleteSectionAnnouncement(announcementId);
        }
    }
}
