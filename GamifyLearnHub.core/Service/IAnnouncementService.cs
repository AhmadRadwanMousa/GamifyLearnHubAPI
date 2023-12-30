using GamifyLearnHub.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyLearnHub.Core.Service
{
    public interface IAnnouncementService
    {
        Task<List<Announcement>> GetAllAnnouncements();
        Task<Announcement> GetAnnouncementById(int id);
        Task<List<Announcement>> GetAnnouncementsBySectionId(int sectionId);
        Task<int> CreateAnnouncement(Announcement announcement);
        Task<int> DeleteAnnouncement(int id);
        Task<int> UpdateAnnouncement(Announcement announcement);
    }
}
