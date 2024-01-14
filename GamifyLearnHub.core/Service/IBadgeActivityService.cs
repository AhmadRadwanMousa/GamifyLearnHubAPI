﻿using GamifyLearnHub.Core.Data;
using GamifyLearnHub.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyLearnHub.Core.Service
{
    public interface IBadgeActivityService
    {
        Task<List<Badgeactivity>> GetAll();
        Task<int> UpdateBadgeActivity(Badgeactivity badgeactivity);
        Task<List<Userbadgeactivity>> GetUserBadgesByUserId(int userId);
        Task<List<Userbadgeactivity>> GetAllUnviewedUserBadges(int userId);
        Task<int> UpdateUserBadgeStatus(UpdateUserBadgeDetails userbadgedetails);


    }
}
