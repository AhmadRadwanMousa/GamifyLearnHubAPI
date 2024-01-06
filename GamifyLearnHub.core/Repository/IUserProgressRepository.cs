using GamifyLearnHub.Core.Data;
using GamifyLearnHub.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyLearnHub.Core.Repository
{
    public interface IUserProgressRepository
    {
        Task<IEnumerable<Userprogress>> GetAllUserProgress();
        Task<Userprogress> GetUserProgressById(decimal id);
        Task<decimal> CreateUserProgress(Userprogress userProgess);
        Task<int> UpdateUserProgress(decimal id, decimal user_id, decimal lecture_id);
        Task<int> DeleteUserProgress(decimal id);
        Task<List<Userprogress>> GetUserProgressBySectionAndUserId(int userId, int sectionId);
        Task<List<UserProgressPerCourse>>GetProgressPerCourse(int userId, int programId);
       

    }
}
