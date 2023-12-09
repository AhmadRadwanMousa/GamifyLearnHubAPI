using GamifyLearnHub.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyLearnHub.Core.Repository
{
    public interface IBadgeActivityRepository
    {
        Task<List<Badgeactivity>> GetAll();
        Task<int> UpdateBadgeActivity(Badgeactivity badgeactivity);
    }
}
