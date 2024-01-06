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
    public class UserProgressService : IUserProgressService
    {
        private readonly IUserProgressRepository _userProgressRepository;

        public UserProgressService(IUserProgressRepository userProgressRepository)
        {
            _userProgressRepository = userProgressRepository;
        }

        public async Task<IEnumerable<Userprogress>> GetAllUserProgress()
        {
            return await _userProgressRepository.GetAllUserProgress();
        }

        public async Task<Userprogress> GetUserProgressById(decimal id)
        {
            return await _userProgressRepository.GetUserProgressById(id);
        }

        public async Task<decimal> CreateUserProgress(Userprogress userprogress)
        {
            return await _userProgressRepository.CreateUserProgress(userprogress);
        }

        public async Task<int> UpdateUserProgress(decimal id, decimal user_id, decimal lecture_id)
        {
            return await _userProgressRepository.UpdateUserProgress(id, user_id, lecture_id);
        }

        public async Task<int> DeleteUserProgress(decimal id)
        {
            return await _userProgressRepository.DeleteUserProgress(id);
        }

        public async Task<List<Userprogress>> GetUserProgressBySectionAndUserId(int userId, int sectionId)
        {
           return await _userProgressRepository.GetUserProgressBySectionAndUserId(userId, sectionId);
        }

        public async Task<List<UserProgressPerCourse>> GetProgressPerCourse(int userId, int programId)
        {
          return await _userProgressRepository.GetProgressPerCourse(userId, programId);   
        }
    }
}
