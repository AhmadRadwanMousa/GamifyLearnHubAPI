using GamifyLearnHub.Core.Data;
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
    public class UserDashboardInfoService : IUserDashboardInfoService
    {
        private readonly IUserDashboardInfoRepository _userDashboardInfoRepository;

        public UserDashboardInfoService(IUserDashboardInfoRepository userDashboardInfoRepository)
        {
            _userDashboardInfoRepository = userDashboardInfoRepository;
        }

        public async Task<List<CompletedCourses>> CompletedCoursesByUserId(int id)
        {
            return await _userDashboardInfoRepository.CompletedCoursesByUserId(id);
        }

        public async Task<List<Attendence>> UserDashboardAttendence(decimal userId, decimal sectionId)
        {
            return await _userDashboardInfoRepository.UserDashboardAttendence(userId, sectionId);
        }

        public async Task<UserDashboarInfo> UserDashboardInfoByUserId(int id)
        {
            return await _userDashboardInfoRepository.UserDashboardInfoByUserId(id);
        }
    }
}
