using GamifyLearnHub.Core.Data;
using GamifyLearnHub.Core.Repository;
using GamifyLearnHub.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyLearnHup.Infra.Service
{
    public class UserSectionService : IUserSectionService
    {
        private readonly IUserSectionRepository _userSectionRepository;

        public UserSectionService(IUserSectionRepository userSectionRepository)
        {
            _userSectionRepository = userSectionRepository;
        }

        public Task<IEnumerable<Usersection>> GetAllUserSections()
        {
            return _userSectionRepository.GetAllUserSections();
        }

        public Task<Usersection> GetUserSectionById(decimal userSectionId)
        {
            return _userSectionRepository.GetUserSectionById(userSectionId);
        }

        public async Task<decimal> CreateUserSection(Usersection userSection)
        {
            return await _userSectionRepository.CreateUserSection(userSection);
        }

        public async Task<int> UpdateUserSection(Usersection userSection)
        {
            return await _userSectionRepository.UpdateUserSection(userSection);
        }

        public async Task<int> DeleteUserSection(decimal userSectionId)
        {
            return await _userSectionRepository.DeleteUserSection(userSectionId);
        }

        public async Task<List<User>> GetAllUserStudents()
        {
           return await _userSectionRepository.GetAllUserStudents();
        }

        public Task<IEnumerable<Usersection>> GetUserSectionsBySectionId(decimal sectionId)
        {
            return _userSectionRepository.GetUserSectionsBySectionId(sectionId);
        }
    }
}
