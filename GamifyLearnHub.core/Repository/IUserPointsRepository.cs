using GamifyLearnHub.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyLearnHub.Core.Repository
{
    public interface IUserPointsRepository
    {
        Task<List<Userpointsactivity>> GetAllUnViewedUserPoints(int userId);
        Task<int> UpdateUserPointsState(int userPointsId);
    }
}
