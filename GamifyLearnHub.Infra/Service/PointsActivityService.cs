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
    public class PointsActivityService : IPointsActivityService
    { 
        private readonly IPointsActivityRepository _pointsActivityRepository;
        public PointsActivityService(IPointsActivityRepository pointsActivityRepository)
        {
            _pointsActivityRepository = pointsActivityRepository;   
        }

        public async Task<int> CreateNewPointsActivity(Pointsactivity pointsactivity)
        {
            return await _pointsActivityRepository.CreateNewPointsActivity(pointsactivity);
        }

        public async Task<List<Pointsactivity>> GetAll()
        {
            return await _pointsActivityRepository.GetAll();
        }

        public async Task<int> UpdatePointsActivity(Pointsactivity pointsactivity)
        {
            return await _pointsActivityRepository.UpdatePointsActivity(pointsactivity);
        }
    }
}
