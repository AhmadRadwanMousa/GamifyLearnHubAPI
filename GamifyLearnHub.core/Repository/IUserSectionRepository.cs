using GamifyLearnHub.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyLearnHub.Core.Repository
{
    public interface IUserSectionRepository
    {
        Task<IEnumerable<Usersection>> GetAllUserSections();
        Task<Usersection> GetUserSectionById(decimal userSectionId);
        Task CreateUserSection(Usersection userSection);
        Task UpdateUserSection(Usersection userSection);
        Task DeleteUserSection(decimal userSectionId);
    }
}
