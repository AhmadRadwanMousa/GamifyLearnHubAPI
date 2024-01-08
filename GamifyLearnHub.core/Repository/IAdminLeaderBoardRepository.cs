using GamifyLearnHub.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyLearnHub.Core.Repository
{
    public interface IAdminLeaderBoardRepository
    {
        Task<List<RankByPoints>> RankByPointsStudents();
        Task<List<RankByBadges>> RankByBadgesStudents();
        Task<List<AdminStatistics>> AdminStatistics();
        Task<int> InstructorStudents(int id);
    }
}
