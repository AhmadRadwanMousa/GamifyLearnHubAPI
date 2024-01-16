using GamifyLearnHub.Core.Data;
using GamifyLearnHub.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyLearnHub.Core.Service
{
    public interface IUserReviewService
    {
        Task<int> CreateUserReview(Userreview userReview);
        Task<List<Userreview>> GetAllUserReviews();
        Task<Userreview> GetUserReviewById(int id);
        Task<int> UpdateUserReview(Userreview userReview);
        Task<int> DeleteUserReview(int id);
        Task<List<FinishedProgram>> GetFinishedPrograms(int userId);
    }
}
