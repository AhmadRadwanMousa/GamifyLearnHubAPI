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
    public class UserPointsService : IUserPointsService
    {
        private readonly IUserPointsRepository _userPointsRepository;
        public UserPointsService(IUserPointsRepository userPointsRepository)
        {
            _userPointsRepository = userPointsRepository;   
        }
        public async Task<List<Userpointsactivity>> GetAllUnViewedUserPoints(int userId)
        {
         return  await _userPointsRepository.GetAllUnViewedUserPoints(userId);    
        }

        public async Task<int> UpdateUserPointsState(int userPointsId)
        {
          return await _userPointsRepository.UpdateUserPointsState(userPointsId); 
        }
    }
}
