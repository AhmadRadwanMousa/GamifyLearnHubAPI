using GamifyLearnHub.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyLearnHub.Core.Repository
{
    public interface ISectionAnnouncementRepository
    {
        Task<IEnumerable<Sectionannoncment>> GetAllSectionAnnouncements();
        Task<Sectionannoncment> GetSectionAnnouncementById(decimal announcementId);
        Task<decimal> CreateSectionAnnouncement(Sectionannoncment sectionAnnouncement);
        Task<int> UpdateSectionAnnouncement(Sectionannoncment sectionAnnouncement);
        Task<int> DeleteSectionAnnouncement(decimal announcementId);
    }
}
