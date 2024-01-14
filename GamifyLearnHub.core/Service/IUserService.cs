using GamifyLearnHub.Core.Data;
using GamifyLearnHub.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyLearnHub.Core.Service
{
    public interface IUserService
    {
        Task<int> CreateUser(UserDetails userDetails);
        Task<int> UpdateUser(UserDetails userDetails);
        Task<int> EditUserProfile(UserDetails userDetails);
        Task<int> DeleteUser(int id);
        Task<User> GetUserById(int id);
        Task<List<User>> GetAllUsers();
        Task<List<User>> GetUnAcceptedUsers();
        Task<int> UpdateUserStatus(int userId, int isAccepted);

        Task<List<ReportsUser>> ReportsByUserId(int userId, int programId);
        Task<List<Program>> GetProgramsByUserId(int userId);

        Task<int> CreateInstructorDetails(Instructordetail instructordetail);
        Task<int> UpdateInstructorDetails(Instructordetail instructordetail);
        Task<int> DeleteInstructorDetails(decimal instructorId);
        Task<Instructordetail> GetInstructorDetailsById(decimal instructorId);

    }
}
