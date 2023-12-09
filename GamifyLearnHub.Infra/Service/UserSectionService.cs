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

        public Task CreateUserSection(Usersection userSection)
        {
            return _userSectionRepository.CreateUserSection(userSection);
        }

        public Task UpdateUserSection(Usersection userSection)
        {
            return _userSectionRepository.UpdateUserSection(userSection);
        }

        public Task DeleteUserSection(decimal userSectionId)
        {
            return _userSectionRepository.DeleteUserSection(userSectionId);
        }
    }
}
