using GamifyLearnHub.Core.DTO;
using GamifyLearnHub.Core.Repository;
using GamifyLearnHub.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyLearnHub.Infra.Service
{
    public class AdminLeaderBoardService : IAdminLeaderBoardService
    {
        private readonly IAdminLeaderBoardRepository _adminLeaderBoardRepository;
        public AdminLeaderBoardService(IAdminLeaderBoardRepository adminLeaderBoardRepository) 
        { 
            _adminLeaderBoardRepository = adminLeaderBoardRepository;   
        }

        public async Task<List<AdminStatistics>> AdminStatistics()
        {
            return await _adminLeaderBoardRepository.AdminStatistics();
        }

        public async Task<int> InstructorStudents(int id)
        {
            return await _adminLeaderBoardRepository.InstructorStudents(id);
        }

        public async Task<List<RankByBadges>> RankByBadgesStudents()
        {
            return await _adminLeaderBoardRepository.RankByBadgesStudents();
        }

        public async Task<List<RankByPoints>> RankByPointsInstructorStudents(int id)
        {
            return await _adminLeaderBoardRepository.RankByPointsInstructorStudents(id);
        }

        public async Task<List<RankByPoints>> RankByPointsStudents()
        {
            return await _adminLeaderBoardRepository.RankByPointsStudents();
        }
    }
}
