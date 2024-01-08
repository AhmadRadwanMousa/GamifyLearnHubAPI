using GamifyLearnHub.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyLearnHub.Core.Service
{
    public interface IAdminLeaderBoardService
    {
        Task<List<RankByPoints>> RankByPointsStudents();
        Task<List<RankByBadges>> RankByBadgesStudents();
        Task<List<AdminStatistics>> AdminStatistics();
        Task<int> InstructorStudents(int id);
        Task<List<RankByPoints>> RankByPointsInstructorStudents(int id);
    }
}
