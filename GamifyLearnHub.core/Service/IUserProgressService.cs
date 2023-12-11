using GamifyLearnHub.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyLearnHub.Core.Service
{
    public interface IUserProgressService
    {
        Task<IEnumerable<Userprogress>> GetAllUserProgress();
        Task<Userprogress> GetUserProgressById(decimal id);
        Task<decimal> CreateUserProgress(decimal user_id, decimal lecture_id);
        Task<int> UpdateUserProgress(decimal id, decimal user_id, decimal lecture_id);
        Task<int> DeleteUserProgress(decimal id);
    }
}
