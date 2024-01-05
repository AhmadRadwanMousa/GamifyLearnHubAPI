using GamifyLearnHub.Core.Data;
using GamifyLearnHub.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyLearnHub.Core.Service
{
    public interface IUserDashboardInfoService
    {
        Task<UserDashboarInfo> UserDashboardInfoByUserId(int id);
        Task<List<Attendence>> UserDashboardAttendence(decimal userId, decimal sectionId);
        Task<List<CompletedCourses>> CompletedCoursesByUserId(int id);
    }
}
