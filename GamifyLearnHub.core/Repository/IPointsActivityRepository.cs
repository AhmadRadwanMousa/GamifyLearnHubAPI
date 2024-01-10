using GamifyLearnHub.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyLearnHub.Core.Repository
{
    public interface IPointsActivityRepository
    {
        Task<List<Pointsactivity>> GetAll();
        Task<int> UpdatePointsActivity(Pointsactivity pointsactivity);
        Task<int> CreateNewPointsActivity(Pointsactivity pointsactivity);

        Task<int> DeletePointsActivity(int id);
    }
}
