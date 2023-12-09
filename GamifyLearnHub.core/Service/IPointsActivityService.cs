﻿using GamifyLearnHub.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyLearnHub.Core.Service
{
    public interface IPointsActivityService
    {
        Task<List<Pointsactivity>> GetAll();
        Task<int> UpdatePointsActivity(Pointsactivity pointsactivity);
    }
}