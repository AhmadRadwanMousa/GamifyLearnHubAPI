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
    public class BadgeActivityService : IBadgeActivityService
    {
        private readonly IBadgeActivityRepository _badgeActivityRepository;

        public BadgeActivityService(IBadgeActivityRepository badgeActivityRepository)
        {
            _badgeActivityRepository = badgeActivityRepository;
        }

        public async Task<List<Badgeactivity>> GetAll()
        {
           return await _badgeActivityRepository.GetAll();
        }

        public async Task<List<Userbadgeactivity>> GetUserBadgesByUserId(int userId)
        {
            return await _badgeActivityRepository.GetUserBadgesByUserId(userId);
        }

        public async Task<int> UpdateBadgeActivity(Badgeactivity badgeactivity)
        {
            return await _badgeActivityRepository.UpdateBadgeActivity(badgeactivity);
        }
    }
}
