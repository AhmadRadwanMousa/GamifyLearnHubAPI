using GamifyLearnHub.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyLearnHub.Core.Service
{
    public interface IUserSectionService
    {
        Task<IEnumerable<Usersection>> GetAllUserSections();
        Task<Usersection> GetUserSectionById(decimal userSectionId);
        Task<List<User>> GetAllUserStudents();
        Task<decimal> CreateUserSection(Usersection userSection);
        Task<int> UpdateUserSection(Usersection userSection);
        Task<int> DeleteUserSection(decimal userSectionId);

        Task<IEnumerable<Usersection>> GetUserSectionsBySectionId(decimal sectionId);

        Task<IEnumerable<User>> GetUsersBySectionId(decimal sectionId);
        Task<int> SetUserAssignmentMark(int mark, int assignmentId, int studentId);

    }
}
